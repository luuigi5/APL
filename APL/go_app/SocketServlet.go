package main 

import (
	"net"
	"fmt"
	"encoding/json"
	"go_app/Entity"
	"go_app/Repository"
)



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
    var response Response
    if err != nil {
		response = GetResponse(500, "Error", "Non è stato possibile inserire l'utente", request)
	} else {
        response = ExecuteActionByRequest(request)
    }
    
	responseBytes, err := json.Marshal(response)
	if err != nil {
		fmt.Printf("Errore nella serializzazione JSON: %v\n", err)
		return
	}

    _, err = conn.Write([]byte(responseBytes))
    if err != nil {
        fmt.Printf("Errore durante l'invio della risposta: %v\n", err)
    }
	defer conn.Close()
}

func ExecuteActionByRequest(req Request)(Response){
	db, dbErr := OpenDBConnection()
	if dbErr != nil {
		return GetResponse(500, "Error", "Non è stato possibile inserire l'utente", req)
	}
    switch req.Action {
		case "createUser":
			user := Entity.Users {
				Username : req.Data.Username,
				Email : req.Data.Email,
				Password : req.Data.Password,
			}
			err := Repository.AddUser(user, db)
			if err != nil{
				return GetResponse(500, "Error", "Non è stato possibile inserire l'utente", req)
			}
			return GetResponse(200, "Success", "Utente inserito", req)
		}
	
	return GetResponse(500, "Error", "Action non gestita", req)
}