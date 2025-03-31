package main

import(
    "database/sql"
    "encoding/json"
    "fmt"
    "os"
    _ "github.com/lib/pq" 
)

type dbParameters struct{
	TypeDb string `json:"typeDb"`
	Host string `json:"host"`
	Port int `json:"port"`
	User string `json:"user"`
	Password string `json:"password"`
	Dbname string `json:"dbname"`
	Sslmode string `json:"sslmode"`
}

type Response struct {
	Code int `json:"code"`
	Status string `json:"status"`
	Description string `json:"description"`
	Request Request `json:"request"`
}

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


// funzione che prende i parametri di connessione del db dal file di configurazione
func getDbConfig(filename string)(dbParameters, error){
	var parametri dbParameters
	file,err := os.Open(filename)
	if err != nil {
		return parametri,err
	}
	defer file.Close()

	decoder := json.NewDecoder(file)
	err = decoder.Decode(&parametri)
	if err != nil {
        return parametri, fmt.Errorf("errore decodifica JSON: %v", err)
	}
	return parametri,err
}

// funzione che ritorna una connessione al db
func OpenDBConnection()(*sql.DB, error){
	//prendo i parametri dal file config
	
	param, err := getDbConfig("config.json")
	if err != nil{
        return nil, fmt.Errorf("errore estrazione parametri: %v", err)
	}
	fmt.Print(param)

	connectionString:= fmt.Sprintf("host=%s port=%d user=%s password=%s dbname=%s sslmode=%s", param.Host, param.Port, param.User,
	 param.Password, param.Dbname, param.Sslmode)
	// Apertura della connessione
	db, err := sql.Open("postgres",connectionString)
	if err != nil {
        return nil, fmt.Errorf("errore apertura connessione: %v", err)
	}
	// Verifica della connessione
	err = db.Ping()
	if err != nil {
		return nil, err
	}
	fmt.Println("Connessione stabilita!")
	return db, err
}

func GetResponse(code int, status string, description string, request Request)(Response){
	 return Response {
		Code: code,
		Status: status,
		Description: description, 
		Request: request,	
	}
}