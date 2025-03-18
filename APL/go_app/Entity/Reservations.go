package Entity

import(
)

type Reservations struct {
	Id int `json:"id" db:"id"`
	Name string `json:"name" db:"name"`
	IdUser int `json:"idUser" db:"idUser"`
	Revenue float64 `json:"revenue" db:"revenue"`
	StartDate string `json:"startDate" db:"startDate"` 
	EndDate string `json:"endDate" db:"endDate"`
}