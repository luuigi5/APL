package main 

import (
	"net"
	"fmt"
	"encoding/json"
	"go_app/Entity"
	"go_app/Repository"
)

type Request struct {
	Action string `json:"action"`
	Data Data `json:"data"`
}

//definisco una tipologia di richiesta che mi potrebbe arrivare dal modulo python
type Data struct {
	Username string `json:"username"`
	Email string `json:"email"`
	Password string `json:"password"`
}

func StartSocketServer() {
	port := "8091"
	listener, err := net.Listen("tcp", "0.0.0.0:8091")
	if err != nil {
		fmt.Printf("Errore durante l'avvio del server : %v", err)
	}
	defer listener.Close()
	fmt.Printf("Server in ascolto su %s\n", port)
	//condizione true per rendere il server sempre attivo
	for {
		connection, err := listener.Accept()
		if err != nil {
			fmt.Printf("Errore durante l'accettazione della connessione : %v", err)
		}
		//chiamo una goroutine per gestire tutte le richieste in maniera concorrenziale
		go ManageRequest(connection)
	}

}


func ManageRequest(conn net.Conn){
	buffer := make([]byte, 4096)
	n, err := conn.Read(buffer)
	if err != nil {
		fmt.Printf("Errore durante la lettura dei dati %v", err)
	}
    jsonData := buffer[:n]
	fmt.Printf("JSON ricevuto: %s\n", string(jsonData))
    
	var request Request
    err = json.Unmarshal(jsonData, &request)
    var response string
    if err != nil {
        response = fmt.Sprintf("Errore nel parsing JSON: %v", err)
    } else {
        response = ExecuteActionByRequest(request)
    }
    
    _, err = conn.Write([]byte(response))
    if err != nil {
        fmt.Printf("Errore durante l'invio della risposta: %v\n", err)
    }
	defer conn.Close()
}

func ExecuteActionByRequest(req Request)(string){
    switch req.Action {
    case "createUser":
        fmt.Printf("Creazione utente: %s\n", req.Data.Username)
		user := Entity.Users {
			Username : req.Data.Username,
			Email : req.Data.Email,
			Password : req.Data.Password,
		}

		db, dbErr := OpenDBConnection()
		if dbErr != nil {
			return "Errore durante l'apertura della connessione"
			
		}
		err := Repository.AddUser(user, db)
		if err != nil{
			return "Errore nell'aggiunta dell'utente"
		}
		return "Utente inserito"
	}
	return "Action non gestita"
}