package Service

import(
	"database/sql"
	"go_app/Entity"
	"go_app/Repository"
	"go_app/Utility"
)

func AddReservation(req Utility.Request, db *sql.DB)(Utility.Response){
	reservation := Entity.Reservations {
		Name : req.Data.NameReservation,
		IdUser : req.Data.IdUser,
		IdStructure : req.Data.IdStructure,
		Revenue : req.Data.Revenue,
		StartDate : req.Data.StartDate,
		EndDate : req.Data.EndDate,
	}
	id, err := Repository.AddReservation(reservation, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile inserire la prenotazione", req, nil)
	}else{
		reservation.Id = id
		var reservations []Entity.Reservations
		reservations = append(reservations, reservation)
		elements := &Utility.GetElement{
			Reservations:reservations,
		} 
		return Utility.CreateResponse(200, "Success", "Prenotazione inserito", req, elements)
	}
}

func UpdateReservation(req Utility.Request, db *sql.DB)(Utility.Response){
	reservation := Entity.Reservations {
		Id: req.Data.IdReservation,
		Name : req.Data.NameReservation,
		IdUser : req.Data.IdUser,
		IdStructure : req.Data.IdStructure,
		Revenue : req.Data.Revenue,
		StartDate : req.Data.StartDate,
		EndDate : req.Data.EndDate,
	}
	err := Repository.UpdateReservation(reservation, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile inserire la prenotazione", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Prenotazione inserito", req, nil)
	}
}

func DeleteReservation(req Utility.Request, db *sql.DB)(Utility.Response){
	err := Repository.DeleteReservation(req.Data.IdReservation, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile eliminare la prenotazione", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Prenotazione eliminata", req, nil)
	}
}

func LoadReservations(req Utility.Request, db *sql.DB)(Utility.Response){
	reservation, err := Repository.LoadReservations(db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile caricare la lista delle prenotazioni", req, nil)
	}else{
		elements := &Utility.GetElement {
			Reservations: reservation,
		}
		return Utility.CreateResponse(200, "Success", "Lista Prenotazioni recuperate", req, elements)
	}
}

//prenotazioni
func GetReservationById(req Utility.Request, db *sql.DB)(Utility.Response){
	reservation, err := Repository.GetReservationById(req.Data.IdReservation, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile recuperare la prenotazione", req, nil)
	}else{
		elements := &Utility.GetElement {
			Reservations: reservation,
		}
		return Utility.CreateResponse(200, "Success", "Prenotazione recuperata", req, elements)
	}
}