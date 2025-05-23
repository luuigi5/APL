package Repository 

import(
	"fmt"
	"go_app/Entity"
	"database/sql"
)

func AddStructure(structure Entity.Structures, db *sql.DB)(int, error){
	sqlStatement := `INSERT INTO structures (name, idUser, city, address, type, rooms, imglink)
		VALUES ($1, $2, $3, $4, $5, $6, $7)
		RETURNING id`
	id := 0
	err := db.QueryRow(sqlStatement, structure.Name, structure.IdUser, structure.City, structure.Address, structure.Type, structure.Rooms, structure.ImgLink).Scan(&id)
	if err != nil {
        return 0, fmt.Errorf("errore durante l'inserimento della struttura: %w", err)
	}
	fmt.Printf("Struttura : %s inserita correttament con id: %d", structure.Name, id)
	return id, nil
}

func UpdateStructure(structure Entity.Structures, db *sql.DB)(error){
	sqlStatement := `UPDATE structures SET name=$1, idUser=$2, city=$3, address=$4, type=$5, rooms=$6, imglink=$7 WHERE id = $8`
	result, err := db.Exec(sqlStatement, structure.Name, structure.IdUser, structure.City, structure.Address, structure.Type, structure.Rooms, structure.ImgLink, structure.Id)
	if err != nil {
		return fmt.Errorf("errore durante l'aggiornamento della struttura: %w", err)
	}
    rowsAffected, err := result.RowsAffected()
    if err != nil {
        return fmt.Errorf("errore nella verifica delle righe modificate: %w", err)
    }
    if rowsAffected == 0 {
        return fmt.Errorf("nessuna struttura trovata con id %d", structure.Id)
    }
	fmt.Printf("La struttura : %s è stata aggiornata correttamente", structure.Name)
    return nil

	return nil
}

func DeleteStructure(id int, db *sql.DB)(error){
	sqlStatement := `DELETE FROM structures WHERE id = $1` 
	_,err := db.Exec(sqlStatement, id)
	return err
}

func LoadStructures(db *sql.DB)([]Entity.Structures, error){
	sqlQuery := `SELECT * FROM structures`
	rows,err := db.Query(sqlQuery)
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var structures []Entity.Structures
	for rows.Next(){
		var structure Entity.Structures
		err = rows.Scan(&structure.Id, &structure.Name, &structure.IdUser, &structure.City, &structure.Address, &structure.Type, &structure.Rooms, &structure.ImgLink)
		if err != nil {
			return nil, err
		}
		structures = append(structures, structure)
	}

	return structures, nil
}

func GetStructureById(structureId int, db *sql.DB)([]Entity.Structures, error){
	sqlQuery := `SELECT * FROM structures WHERE id = $1`
	var structure Entity.Structures
	var structures []Entity.Structures
	err := db.QueryRow(sqlQuery, structureId).Scan(&structure.Id, &structure.Name, &structure.IdUser, &structure.City, &structure.Address, &structure.Type, &structure.Rooms, &structure.ImgLink)
	if err != nil{
		return structures, err
	}
	structures = append(structures, structure)
	return structures, nil
}

func GetStructureByIdUser(userId int, db *sql.DB)([]Entity.Structures, error){
	sqlQuery := `SELECT * FROM structures WHERE idUser = $1`
	rows,err := db.Query(sqlQuery, userId)
	if err != nil{
		return nil, err
	}
	defer rows.Close()
	var structures []Entity.Structures

	for rows.Next(){
		var structure Entity.Structures
		err = rows.Scan(&structure.Id, &structure.Name, &structure.IdUser, &structure.City, &structure.Address, &structure.Type, &structure.Rooms, &structure.ImgLink)
		if err != nil {
			return nil, err
		}
		structures = append(structures, structure)
	}
	return structures, nil
}
