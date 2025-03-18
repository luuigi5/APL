package Entity

import(
	"time"
)

type Users struct {
	Id int `json:"id" db:"id"`
	Username string `json:"username" db:"username"`
	Email string `json:"email" db:"email"`
	Password string `json:"password" db:"password"` //N.B. SE come campo json inserisco -, non verrà inserito nel json prodotto 
	CreatedAt time.Time `json:"createdAt" db:"created_at"`
}
