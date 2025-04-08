import json

class Structure:
    def __init__(self, name, idUser, type, rooms, idStructure=None):
        if idStructure is not None:
            self.idStructure = idStructure
        self.name = name
        self.idUser = idUser 
        self.type = type
        self.rooms = rooms

    def __str__(self):
        return f"Structure(idStructure={self.idStructure}, name={self.name}, idUser={self.idUser}, type={self.type}, rooms={self.rooms})"


    def aggiungiStruttura(self, clientSocket):
        request = {
            "action": "createStructure",
            "data": {
                "nameStructure": self.name,
                "idUser": self.idUser,
                "type": self.type,
                "rooms": self.rooms
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
       
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        if responseJson["code"] == 200:
            self.idStructure = responseJson["elements"]["structures"][0]["id"]
        return responseJson
    
    def eliminaStruttura(self, clientSocket):
        request = {
            "action": "deleteStructure",
            "data": {
                "idUser": self.idStructure
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        return responseJson
    
    def aggiornaStruttura(self, clientSocket):
        request = {
            "action": "updateStructure",
            "data": {
                "idStructure": self.idStructure,
                "nameStructure": self.name,
                "idUser": self.idUser,
                "type": self.type,
                "rooms": self.rooms
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaStrutturaTramiteId(idStructure, clientSocket):
        request = {
            "action": "getStructureById",
            "data": {
                "idStructure": idStructure
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaStrutture(clientSocket):
        request = {
            "action": "getAllStructure"
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(4096)

        responseJson = json.loads(response.decode())
        return responseJson