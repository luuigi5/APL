import json
import bcrypt
import datetime
import jwt
class User:
    def __init__(self, username, email, password, idUser=None):
        if idUser is not None:
            self.idUser = idUser
        self.username = username
        self.email = email 
        self.password = password

    def __str__(self):
        return f"User(username={self.username}, email={self.email}, idUser={self.idUser})"

    def login(self, clientSocket):
        request = {
            "action":"login",
            "data":{
                "username": self.username
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        if responseJson["code"] == 200:
            pwd = responseJson["elements"]["users"][0]["password"]
            if bcrypt.checkpw(self.password.encode('utf-8'), pwd.encode('utf-8')):
                self.idUser =  responseJson["elements"]["users"][0]["id"]
                token = createJwtToken(self.idUser, self.username)
                return {"token": token}
            else:
                print("Le due password non coincidono")
                return {"success": False, "error": "Password non valida"}

    
    def aggiungiUtente(self, clientSocket):
        hashedPwd = hashPassword(self.password)
        request = {
            "action": "createUser",
            "data": {
                "username": self.username,
                "email": self.email,
                "password": hashedPwd
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
       
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        #print(f"{responseJson}")
        if responseJson["code"] == 200:
            self.idUser = responseJson["elements"]["users"][0]["id"]
        return responseJson
    
    def eliminaUtente(self, clientSocket):
        request = {
            "action": "deleteUser",
            "data": {
                "idUser": self.idUser
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        return responseJson
    
    def aggiornaUtente(self, clientSocket):
        request = {
            "action": "updateUser",
            "data": {
                "idUser": self.idUser,
                "username":self.username,
                "email":self.email,
                "password": self.password,
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaUtenteTramiteId(idUser, clientSocket):
        request = {
            "action": "getUserById",
            "data": {
                "idUser": idUser
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaUtenti(clientSocket):
        request = {
            "action": "getAllUser"
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(4096)

        responseJson = json.loads(response.decode())
        return responseJson

def hashPassword(pwd):
    salt = bcrypt.gensalt()
    # Calcola l'hash della password con il salt
    hashed = bcrypt.hashpw(pwd.encode('utf-8'), salt)
    return hashed.decode('utf-8')  

def createJwtToken(idUser, username):
    key = "key_Token_jwt_temporary123!"
    payload = {
        "idUser": idUser,
        "username": username, 
        "iat": datetime.datetime.utcnow(),  # Issued At
        "exp": datetime.datetime.utcnow() + datetime.timedelta(hours=24)  #Scadenza simbolica token di 24 ore dal rilascio
    }

    token = jwt.encode(payload, key, algorithm="HS256")
    print("TOKEN JWT:")
    print(token)
    return token

