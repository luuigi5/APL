import json

class Reservation:
    def __init__(self, idUser, idStructure, revenue, startDate, endDate, idReservation=None):
        if idReservation is not None:
            self.idReservation = idReservation
        self.idUser = idUser 
        self.idStructure = idStructure 
        self.revenue = revenue
        self.startDate = startDate
        self.endDate = endDate


    def __str__(self):
        return f"Reservation(idReservation={self.idReservation}, idStructure={self.idStructure}, idUser={self.idUser}, revenue={self.revenue}, startDate={self.startDate}, endDate={self.endDate})"


    def aggiungiPrenotazione(self, clientSocket):
        request = {
            "action": "createReservation",
            "data": {
                "idUser": self.idUser,
                "idStructure": self.idStructure,
                "revenue": self.revenue,
                "startDate": self.startDate,
                "endDate": self.endDate
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
       
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        if responseJson["code"] == 200:
            self.idReservation = responseJson["elements"]["reservations"][0]["id"]
        return responseJson
    
    def eliminaPrenotazione(self, clientSocket):
        request = {
            "action": "deleteReservation",
            "data": {
                "idReservation": self.idReservation
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        
        response = clientSocket.recv(1024)
        responseJson = json.loads(response.decode())
        return responseJson
    
    def aggiornaPrenotazione(self, clientSocket):
        request = {
            "action": "updateReservation",
            "data": {
                "idReservation": self.idReservation,
                "idUser": self.idUser,
                "idStructure": self.idStructure,
                "revenue": self.revenue,
                "startDate": self.startDate,
                "endDate": self.endDate
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaPrenotazioniTramiteId(idReservation, clientSocket):
        request = {
            "action": "getReservationById",
            "data": {
                "idReservation": idReservation
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(1024)

        responseJson = json.loads(response.decode())
        return responseJson
    
    def caricaPrenotazioni(clientSocket):
        request = {
            "action": "getAllReservation"
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        response = clientSocket.recv(4096)

        responseJson = json.loads(response.decode())
        return responseJson