import json

class User:
    def __init__(self, username, email, password, idUser=None):
        if idUser is not None:
            self.idUser = idUser
        self.username = username
        self.email = email 
        self.password = password

    def __str__(self):
        return f"User(username={self.username}, email={self.email}, idUser={self.idUser})"


    def aggiungiUtente(self, clientSocket):
        request = {
            "action": "createUser",
            "data": {
                "username": self.username,
                "email": self.email,
                "password": self.password
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