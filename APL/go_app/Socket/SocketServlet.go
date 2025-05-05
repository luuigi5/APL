package Socket 

import (
	"net"
	"fmt"
	"encoding/json"
	"go_app/Service"
	"go_app/Utility"
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
	fmt.Printf("\nJSON RICEVUTO: %s\n", string(jsonData))
    
	var request Utility.Request
    err = json.Unmarshal(jsonData, &request)
    var response Utility.Response
    if err != nil {
		response = Utility.CreateResponse(500, "Error", "Non è stato possibile elaborare la richiesta", request, nil)
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

func ExecuteActionByRequest(req Utility.Request)(Utility.Response){
	db, dbErr := Utility.OpenDBConnection()
	if dbErr != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile eseguire la richiesta", req, nil)
	}
	var response Utility.Response
    switch req.Action {
		case "login":
			response = Service.Login(req, db)
		case "createUser":
			response = Service.AddUser(req, db)
		case "updateUser":
			response = Service.UpdateUser(req,db)
		case "deleteUser":
			response = Service.DeleteUser(req, db)
		case "getUserById":
			response = Service.GetUserById(req, db)
		case "getAllUser":
			response = Service.LoadUsers(req, db)

		case "createStructure":
			response = Service.AddStructure(req, db)
		case "updateStructure":
			response = Service.UpdateStructure(req,db)
		case "deleteStructure":
			response = Service.DeleteStructure(req, db)
		case "getStructureById":
			response = Service.GetStructureById(req, db)
		case "getStructureByIdUser":
			response = Service.GetStructureByIdUser(req, db)
		case "getAllStructure":
			response = Service.LoadStructures(req, db)

		case "createReservation":
			response = Service.AddReservation(req, db)
		case "updateReservation":
			response = Service.UpdateReservation(req,db)
		case "deleteReservation":
			response = Service.DeleteReservation(req, db)
		case "getReservationById":
			response = Service.GetReservationById(req, db)
		case "getAllReservation":
			response = Service.LoadReservations(req, db)

		default:
		response = Utility.CreateResponse(400, "Bad Request", "Action non gestita: " + req.Action, req, nil)
	}
	return response
}