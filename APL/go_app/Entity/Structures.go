package Entity

import(

)

type Structures struct {
	Id int `json:"id" db:"id"`
	Name string `json:"name" db:"name"`
	IdUser int `json:"idUser" db:"idUser"`
	Type string `json:"type" db:"type"`
	Rooms int `json:"rooms" db:"rooms"`
}