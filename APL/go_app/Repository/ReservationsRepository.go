package Repository 

import(
	"fmt"
	"go_app/Entity"
	"database/sql"
)

func AddReservation(reservation Entity.Reservations, db *sql.DB)(error){
	sqlStatement := `INSERT INTO reservations (name, idUser, revenue, startDate, endDate)
		VALUES ($1, $2, $3, $4, $5)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, reservation.Name, reservation.IdUser, reservation.Revenue, 
		reservation.StartDate, reservation.EndDate).Scan(&id)
	if err != nil {
        return fmt.Errorf("errore durante l'inserimento della prenotazione: %w", err)
	}
	fmt.Printf("Prenotazione per la stanza: %s inserita correttament con id: %d", reservation.Name, id)
	return nil
}

func DeleteReservation(id int, db *sql.DB)(error){
	sqlStatement := `DELETE FROM reservations WHERE id = $1` 
	_,err := db.Exec(sqlStatement, id)
	return err
}

func LoadReservations(idUser int ,db *sql.DB)([]Entity.Reservations, error){
	sqlQuery := `SELECT * FROM reservations WHERE idUser = $1`
	rows,err := db.Query(sqlQuery, idUser)
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var reservations []Entity.Reservations
	for rows.Next(){
		var reservation Entity.Reservations
		err = rows.Scan(&reservation.Name, &reservation.IdUser, &reservation.Revenue, 
			&reservation.StartDate, &reservation.EndDate)
		if err != nil {
			return nil, err
		}
		reservations = append(reservations, reservation)
	}

	return reservations, nil
}

func GetReservationById(reservationId int, db *sql.DB)(Entity.Reservations, error){
	sqlQuery := `SELECT * FROM reservations WHERE id = $1`
	var res Entity.Reservations
	err := db.QueryRow(sqlQuery, reservationId).Scan(&res.Name, &res.IdUser, &res.Revenue, &res.StartDate, &res.EndDate)
	if err != nil{
		return res, err
	}
	return res, nil
}

