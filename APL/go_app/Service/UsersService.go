package Service

import(
	"go_app/Entity"
	"go_app/Repository"
	"go_app/Utility"
	"database/sql"
)

func AddUser(req Utility.Request, db *sql.DB)(Utility.Response){
	user := Entity.Users {
		Username : req.Data.Username,
		Email : req.Data.Email,
		Password : req.Data.Password,
	}
	id, err := Repository.AddUser(user, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile inserire l'utente", req, nil)
	}else{
		user.Id = id
		var users []Entity.Users
		users = append(users, user)
		elements := &Utility.GetElement {
			Users: users,
		}
		return Utility.CreateResponse(200, "Success", "Utente inserito", req, elements)
	}
}

func UpdateUser(req Utility.Request, db *sql.DB)(Utility.Response){
	user := Entity.Users {
		Id : req.Data.IdUser,
		Username : req.Data.Username,
		Email : req.Data.Email,
		Password : req.Data.Password,
	}
	err := Repository.UpdateUser(user, db)
	if err != nil{
		return Utility.CreateResponse(500, "Error", "Non è stato possibile aggiornare l'utente", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Utente inserito", req, nil)
	}
}

func DeleteUser(req Utility.Request, db *sql.DB)(Utility.Response){
	err := Repository.DeleteUser(req.Data.IdUser, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile eliminare l'utente", req, nil)
	}else{
		return Utility.CreateResponse(200, "Success", "Utente eliminato", req, nil)
	}
}

func LoadUsers(req Utility.Request, db *sql.DB)(Utility.Response){
	users, err := Repository.LoadUsers(db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile caricare la lista degli utenti", req, nil)
	}else{
		elements := &Utility.GetElement {
			Users: users,
		}
		return Utility.CreateResponse(200, "Success", "Utente recuperato", req, elements)
	}
}

func GetUserById(req Utility.Request, db *sql.DB)(Utility.Response){
	user, err := Repository.GetUserById(req.Data.IdUser, db)
	if err != nil {
		return Utility.CreateResponse(500, "Error", "Non è stato possibile recuperare l'utente", req, nil)
	}else{
		elements := &Utility.GetElement {
			Users: user,
		}
		return Utility.CreateResponse(200, "Success", "Utente recuperato", req, elements)
	}
}