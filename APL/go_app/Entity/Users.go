package Entity

import(
)

type Users struct {
	Id int `json:"id" db:"id"`
	Username string `json:"username" db:"username"`
	Email string `json:"email" db:"email"`
	Password string `json:"password" db:"password"` //N.B. SE come campo json inserisco -, non verrà inserito nel json prodotto 
}
