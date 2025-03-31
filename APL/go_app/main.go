package main

import (
	"fmt"
	"go_app/Entity"
	"go_app/Repository"
	_ "github.com/lib/pq"
)

func mainDB() {

	db, err := OpenDBConnection()
	if err != nil{
		fmt.Println("Errore durante la connessione con il db")
		return
	}

	user1 := Entity.Users{
		Username: "mario",
		Email: "marioLç@champ.com",
		Password: "WorCion",
	}
	user2 := Entity.Users{
		Username: "Andre",
		Email: "BonHJMo@miss.it",
		Password: "HaTime",
	}

	struttura1 := Entity.Structures{
		Name : "FloresRoom",
		IdUser : 65,
		Type : "B&B",
		Rooms : 5,
	}

	struttura2 := Entity.Structures{
		Name : "MoonHotel",
		IdUser : 66,
		Type : "Hotel",
		Rooms : 46,
	}

	utentiArr := [2]Entity.Users{user1, user2}
	for i:=0; i<len(utentiArr); i++ {
		err := Repository.AddUser(utentiArr[i], db)
		if err != nil{
			fmt.Println("Errore durante l'inserimento degli utenti")
			//fmt.Errorf("errore apertura connessione: %v", err)
			return
		}
	}

	strutture := [2]Entity.Structures{struttura1, struttura2}
	for i:=0; i<len(strutture); i++ {
		err := Repository.AddStructure(strutture[i], db)
		if err != nil{
			fmt.Println("Errore durante l'inserimento delle strutture")
			return
		}
	}


	prenotazione1 := Entity.Reservations{
		Name : "FloresRoom3",
		IdUser : 66,
		IdStructure : 6,
		Revenue : 80,
		StartDate : "20-03-2025",
		EndDate : "21-03-2025",
	}
	errorAdd := Repository.AddReservation(prenotazione1, db)
	if errorAdd != nil{
		fmt.Println("Errore durante l'inserimento della prenotazione")
		//fmt.Errorf("errore apertura connessione: %v", err)
		return
	}
	

	/*errorDelete := Repository.DeleteUser(55, db)
	if errorDelete != nil{
		fmt.Println("Errore durante l'eliminazione degli utenti")
		fmt.Errorf("errore eliminazione utenti: %v", errorDelete)
		return
	}*/

	//Esempio GET USER BY ID
	/*var utente Entity.Users
	utente, err = Repository.GetUserById(14, db)
	if err != nil{
		fmt.Println("Errore durante la get degli utenti")
		fmt.Errorf("errore get utenti: %v", err)
		return
	}else {
		fmt.Print(utente)
	}

	//ESEMPIO GET ALL
	utenti, err := Repository.LoadUsers(db)
	if err != nil{
		fmt.Println("Errore durante la get degli utenti")
		fmt.Errorf("errore get utenti: %v", err)
		return
	}else{
		fmt.Print(utenti)
	}
	defer db.Close() */
	fmt.Println("Tutti le operazioni sono state completate con successo!")

}

//MAIN AVVIO SERVER
func main(){
	StartSocketServer()
}