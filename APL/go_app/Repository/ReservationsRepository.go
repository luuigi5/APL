package Repository 

import(
	"fmt"
	"go_app/Entity"
	"database/sql"
)

func AddReservation(reservation Entity.Reservations, db *sql.DB)(int, error){
	sqlStatement := `INSERT INTO reservations (idUser, idStructure, revenue, startDate, endDate)
		VALUES ($1, $2, $3, $4, $5)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, reservation.IdUser, reservation.IdStructure,
		reservation.Revenue, reservation.StartDate, reservation.EndDate).Scan(&id)
	if err != nil {
        return 0, fmt.Errorf("errore durante l'inserimento della prenotazione: %w", err)
	}
	fmt.Printf("Prenotazione inserita correttament con id: %d", id)
	return id, nil
}

func UpdateReservation(reservation Entity.Reservations, db *sql.DB)(error){
	sqlStatement := `UPDATE reservations SET idUser=$1, idStructure=$2, revenue=$3, startDate=$4, endDate=$5 WHERE id = $6`
	result, err := db.Exec(sqlStatement, reservation.IdUser, reservation.IdStructure,
		reservation.Revenue, reservation.StartDate, reservation.EndDate, reservation.Id)
	if err != nil {
		return fmt.Errorf("errore durante l'aggiornamento della prenotazione: %w", err)
	}
	rowsAffected, err := result.RowsAffected()
	if err != nil {
		return fmt.Errorf("errore nella verifica delle righe modificate: %w", err)
	}
	if rowsAffected == 0 {
		return fmt.Errorf("nessun prenotazione trovato con id %d", reservation.Id)
	}
	fmt.Printf("Prenotazione aggiornata correttamente")
	return nil
}

func DeleteReservation(id int, db *sql.DB)(error){
	sqlStatement := `DELETE FROM reservations WHERE id = $1` 
	_,err := db.Exec(sqlStatement, id)
	return err
}

func LoadReservations(db *sql.DB)([]Entity.Reservations, error){
	sqlQuery := `SELECT * FROM reservations`
	rows,err := db.Query(sqlQuery)
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var reservations []Entity.Reservations
	for rows.Next(){
		var reservation Entity.Reservations
		err = rows.Scan(&reservation.Id, &reservation.IdUser, &reservation.IdStructure, &reservation.Revenue, 
			&reservation.StartDate, &reservation.EndDate)
		if err != nil {
			return nil, err
		}
		reservations = append(reservations, reservation)
	}

	return reservations, nil
}

func GetReservationById(reservationId int, db *sql.DB)([]Entity.Reservations, error){
	sqlQuery := `SELECT * FROM reservations WHERE id = $1`
	var res Entity.Reservations
	var reservations []Entity.Reservations
	err := db.QueryRow(sqlQuery, reservationId).Scan(&res.Id, &res.IdUser, &res.IdStructure, &res.Revenue, &res.StartDate, &res.EndDate)
	if err != nil{
		return reservations, err
	}
	reservations = append(reservations, res)

	return reservations, nil
}

