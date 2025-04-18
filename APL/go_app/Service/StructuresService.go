package Service

import(
	"go_app/Entity"
	"go_app/Repository"
	"go_app/Utility"
	"database/sql"
)

func AddStructure(req Utility.Request, db *sql.DB)(Utility.Response){
	structure := Entity.Structures {
		Name : req.Data.NameStructure,
		IdUser: req.Data.IdUser,
		City: req.Data.City,
		Address: req.Data.Address,
		Type : req.Data.Type,
		Rooms : req.Data.Rooms,
	}
	id, err := Repository.AddStructure(structure, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile inserire la struttura", req, nil)
	}else{
		structure.Id = id
		var structures []Entity.Structures
		structures = append(structures, structure)
		elements := &Utility.GetElement {
			Structures: structures,
		}
		return Utility.CreateResponse(200, "Success", "Struttura inserita", req, elements)
	}
}

func UpdateStructure(req Utility.Request, db *sql.DB)(Utility.Response){
	structure := Entity.Structures {
		Id : req.Data.IdStructure,
		Name : req.Data.NameStructure,
		IdUser : req.Data.IdUser,
		City: req.Data.City,
		Address: req.Data.Address,
		Type : req.Data.Type,
		Rooms : req.Data.Rooms,
	}
	err := Repository.UpdateStructure(structure, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile aggiornare la struttura", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Struttura inserita", req, nil)
	}
}

func DeleteStructure(req Utility.Request, db *sql.DB)(Utility.Response){
	err := Repository.DeleteStructure(req.Data.IdStructure, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile eliminare la struttura", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Struttura eliminata", req, nil)
	}
}

func LoadStructures(req Utility.Request, db *sql.DB)(Utility.Response){
	structures, err := Repository.LoadStructures(db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile caricare la lista delle strutture", req, nil)
	}else{
		elements := &Utility.GetElement {
			Structures: structures,
		}
		return Utility.CreateResponse(200, "Success", "Lista Strutture recuperate", req, elements)
	}
}

func GetStructureById(req Utility.Request, db *sql.DB)(Utility.Response){
	structure, err := Repository.GetStructureById(req.Data.IdStructure, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile recuperare la struttura", req, nil)
	}else{
		elements := &Utility.GetElement {
			Structures: structure,
		}
		return Utility.CreateResponse(200, "Success", "Struttura recuperata", req, elements)
	}
}