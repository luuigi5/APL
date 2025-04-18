package Socket

import(
	"fmt"
	"log"
	"github.com/gorilla/websocket"
	"go_app/Entity"
	"net/http"
	"encoding/json"
	"go_app/Utility"
	"go_app/Service"
	//"math/rand"
	"time"
	"database/sql"
)

var upgrader = websocket.Upgrader{
	ReadBufferSize:1024,
	WriteBufferSize:1024,
	CheckOrigin:func(r *http.Request) bool { return true },
}

func callDB()(*sql.DB){
	db, dbErr := Utility.OpenDBConnection()
	if dbErr != nil {
		return nil
	}
	return db
}

func LoadStructures(){
	db := callDB()
	req := Utility.Request{
		Action: "getAllStructure",
	}
	resp := Service.LoadStructures(req,db)
	fmt.Print(resp)
	//deserializzo il json, prendo dinamicamente una structure a caso --> reservation 
	/*var structures [] Entity.Structures
	structures = json.Unmarshal(resp.Elements)*/
}


func Connect(w http.ResponseWriter, r *http.Request){
	//converto la conversione da http a WebSocket tramite l'oggetto upgrader
	//ws contiene la connessione col client
	ws,err := upgrader.Upgrade(w, r, nil)
	if err != nil{
		fmt.Printf("Errore nella conversione della richiesta\n")
	}
	defer ws.Close()
	for {
		reservation := Entity.Reservations{
			IdUser : 138,
			IdStructure : 10,
			Revenue : 145,
			StartDate : "14-04-2025",
			EndDate : "16-04-2025",
		}

		jsonData, err := json.Marshal(reservation)
        if err != nil {
            log.Printf("Errore nella codifica JSON: %v", err)
            break
        }

        if err := ws.WriteMessage(websocket.TextMessage, jsonData); err != nil {
            log.Printf("Errore nell'invio del messaggio: %v", err)
            break
        }

        log.Printf("Dati inviati: %+v", reservation)
        time.Sleep(100 * time.Second)

	}	
}