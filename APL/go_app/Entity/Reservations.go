package Entity

import(
)

type Reservations struct {
	Id int `json:"id" db:"id"`
	IdUser int `json:"idUser" db:"idUser"`
	IdStructure int `json:"idStructure" db:"idStructure"`
	Revenue float64 `json:"revenue" db:"revenue"`
	StartDate string `json:"startDate" db:"startDate"` 
	EndDate string `json:"endDate" db:"endDate"`
}