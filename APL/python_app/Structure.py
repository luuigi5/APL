import json

class Structure:
    def __init__(self, name, idUser, city, address, type, rooms, imglink, idStructure=None):
        if idStructure is not None:
            self.idStructure = idStructure
        self.name = name
        self.idUser = idUser
        self.city = city
        self.address = address
        self.type = type
        self.rooms = rooms
        self.imglink = imglink


    def __str__(self):
        return f"Structure(idStructure={self.idStructure}, name={self.name}, idUser={self.idUser}, city={self.city}, address={self.address}, type={self.type}, rooms={self.rooms}, imglink={self.imglink})"


    def aggiungiStruttura(self, clientSocket):
        request = {
            "action": "createStructure",
            "data": {
                "nameStructure": self.name,
                "idUser": self.idUser,
                "city": self.city, 
                "address": self.address,
                "type": self.type,
                "rooms": self.rooms, 
                "imglink": self.imglink
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
       
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        if responseJson["code"] == 200:
            self.idStructure = responseJson["elements"]["structures"][0]["id"]
            return  {
                        "status": 200,
                        "structure": {
                            "id": self.idStructure,
                            "name": self.name,
                            "idUser": self.idUser,
                            "city": self.city,
                            "address": self.address,
                            "type": self.type,
                            "rooms": self.rooms,
                            "imglink": self.imglink
                        }
                    }
        else:
            return {"status": 500, "error": "Errore durante l'inserimento della struttura"}

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
                "city": self.city, 
                "address": self.address,
                "type": self.type,
                "rooms": self.rooms,
                "imglink": self.imglink
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaStrutturaTramiteIdUser(idUser, clientSocket):
        request = {
            "action": "getStructureByIdUser",
            "data": {
                "idUser": idUser
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        print (responseJson)
        return response
        """if responseJson["code"] == 200:
            return  {
                        "status": 200,
                        "structure": {
                            "id": responseJson["elements"]["structures"][0]["id"],
                            "name": responseJson["elements"]["structures"][0]["name"],
                            "idUser": responseJson["elements"]["structures"][0]["idUser"],
                            "city": responseJson["elements"]["structures"][0]["city"],
                            "address": responseJson["elements"]["structures"][0]["city"],
                            "type": responseJson["elements"]["structures"][0]["city"],
                            "rooms": responseJson["elements"]["structures"][0]["city"],
                            "imglink": responseJson["elements"]["structures"][0]["city"],
                        }
                    }
        else:
            return {"status": 500, "error": "Errore durante l'inserimento della struttura"}"""



    def caricaStrutture(clientSocket):
        request = {
            "action": "getAllStructure"
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(4096)

        responseJson = json.loads(response.decode())
        return responseJson