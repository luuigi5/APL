package Repository 

import(
	"fmt"
	"time"
	"go_app/Entity"
	"database/sql"
)

func AddUser(utente Entity.Users, db *sql.DB)(int, error){
	sqlStatement := `INSERT INTO users (username, email, password, created_at)
		VALUES ($1, $2, $3, $4)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, utente.Username, utente.Email, utente.Password, time.Now()).Scan(&id)
	if err != nil {
        return 0, fmt.Errorf("errore durante l'inserimento dell'utente: %w", err)
	}
	fmt.Printf("Utente con username: %s inserito correttament con id: %d", utente.Username, id)
	return id, nil
}

func UpdateUser(utente Entity.Users, db *sql.DB)(error){
	sqlStatement := `UPDATE users SET username = $1, email =$2, password=$3, created_at=$4 WHERE id= $5`
    result, err := db.Exec(sqlStatement, utente.Username, utente.Email, utente.Password, time.Now(), utente.Id)
    if err != nil {
        return fmt.Errorf("errore durante l'aggiornamento dell'utente: %w", err)
    }
    
    rowsAffected, err := result.RowsAffected()
    if err != nil {
        return fmt.Errorf("errore nella verifica delle righe modificate: %w", err)
    }
    
    if rowsAffected == 0 {
        return fmt.Errorf("nessun utente trovato con id %d", utente.Id)
    }
    
    fmt.Printf("Utente con username: %s aggiornato correttamente", utente.Username)
    return nil
}

func DeleteUser(id int, db *sql.DB)(error){
	sqlStatement := `DELETE FROM users WHERE id = $1` 
	_,err := db.Exec(sqlStatement, id)
	return err
}

func LoadUsers(db *sql.DB)([]Entity.Users, error){
	sqlQuery := `SELECT * FROM users`
	rows,err := db.Query(sqlQuery)//il metodo query restituisce più righe
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var users []Entity.Users
	//casting delle rows provenienti dalla query in oggetti users
	for rows.Next(){
		var user Entity.Users
		err = rows.Scan(&user.Id, &user.Username, &user.Email, &user.Password, &user.CreatedAt)
		if err != nil {
			return nil, err
		}
		users = append(users, user)
	}

	return users, nil
}

func GetUserById(userId int, db *sql.DB)([]Entity.Users, error){
	sqlQuery := `SELECT * FROM users WHERE id = $1`
	var users []Entity.Users
	var user Entity.Users
	err := db.QueryRow(sqlQuery, userId).Scan(&user.Id, &user.Username, &user.Email, &user.Password, &user.CreatedAt)
	if err != nil{
		return users, err
	}
	users = append(users, user)
	return users, nil
}

