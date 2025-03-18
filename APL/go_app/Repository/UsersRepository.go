package Repository 

import(
	"fmt"
	"time"
	"go_app/Entity"
	"database/sql"
)

func AddUser(utente Entity.Users, db *sql.DB)(error){
	//fmt.Print(utente)
	sqlStatement := `INSERT INTO users (username, email, password, created_at)
		VALUES ($1, $2, $3, $4)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, utente.Username, utente.Email, utente.Password, time.Now()).Scan(&id)
	if err != nil {
        return fmt.Errorf("errore durante l'inserimento dell'utente: %w", err)
	}
	fmt.Printf("Utente con username: %s inserito correttament con id: %d", utente.Username, id)
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

func GetUserById(userId int, db *sql.DB)(Entity.Users, error){
	sqlQuery := `SELECT * FROM users WHERE id = $1`
	var user Entity.Users
	err := db.QueryRow(sqlQuery, userId).Scan(&user.Id, &user.Username, &user.Email, &user.Password, &user.CreatedAt)
	if err != nil{
		return user, err
	}
	return user, nil
}

