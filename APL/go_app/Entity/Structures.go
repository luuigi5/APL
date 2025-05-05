package Entity

import(

)

type Structures struct {
	Id int `json:"id" db:"id"`
	Name string `json:"name" db:"name"`
	IdUser int `json:"idUser" db:"idUser"`
	City string `json:"city" db:"city"`
	Address string `json:"address" db:"address"`
	Type string `json:"type" db:"type"`
	Rooms int `json:"rooms" db:"rooms"`
	ImgLink string `json:"imglink" db:"imglink"`
}