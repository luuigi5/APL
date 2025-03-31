package Repository 

import(
	"fmt"
	"go_app/Entity"
	"database/sql"
)

//TODO RITORNARE ANCHE ID COME TIPO DI RITORNO
func AddStructure(structure Entity.Structures, db *sql.DB)(error){
	sqlStatement := `INSERT INTO structures (name, idUser, type, rooms)
		VALUES ($1, $2, $3, $4)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, structure.Name, structure.IdUser, structure.Type, structure.Rooms).Scan(&id)
	if err != nil {
        return fmt.Errorf("errore durante l'inserimento della struttura: %w", err)
	}
	fmt.Printf("Struttura : %s inserita correttament con id: %d", structure.Name, id)
	return nil
}

func DeleteStructure(id int, db *sql.DB)(error){
	sqlStatement := `DELETE FROM structures WHERE id = $1` 
	_,err := db.Exec(sqlStatement, id)
	return err
}

func LoadStructures(idUser int ,db *sql.DB)([]Entity.Structures, error){
	sqlQuery := `SELECT * FROM structures WHERE idUser = $1`
	rows,err := db.Query(sqlQuery, idUser)
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var structures []Entity.Structures
	for rows.Next(){
		var structure Entity.Structures
		err = rows.Scan(&structure.Id, &structure.Name, &structure.IdUser, &structure.Type, &structure.Rooms)
		if err != nil {
			return nil, err
		}
		structures = append(structures, structure)
	}

	return structures, nil
}

func GetStructureById(structureId int, db *sql.DB)(Entity.Structures, error){
	sqlQuery := `SELECT * FROM structures WHERE id = $1`
	var res Entity.Structures
	err := db.QueryRow(sqlQuery, structureId).Scan(&res.Id, &res.Name, &res.IdUser, &res.Type, &res.Rooms)
	if err != nil{
		return res, err
	}
	return res, nil
}

