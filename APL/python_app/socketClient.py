import socket
from User import User
from Structure import Structure
from Reservation import Reservation
import json

#HOST = '127.0.0.1'
HOST = 'go_app'
PORT = 8091

def createSocket():
    serverAdd = ('go_app', 8091)
    clientSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    clientSocket.connect(serverAdd)
    return clientSocket


def doOperation(action, payload):
    try:
        if(action == 'login'):
            #utente = User("Al", "al@renthouse.it", "apartamentPwdSyd", None)
            utente = User(payload['username'], payload['password'])
            clientSocket = createSocket()
            responseLogin = json.dumps(utente.login(clientSocket))
            clientSocket.close()
            print("Risposta: ", json.dumps(responseLogin))
            return json.dumps(responseLogin)


        #N.B. per ogni operazione va ricreato il Socket
        #CREA UTENTE
        """clientSocket = createSocket()
        utente = User("Al", "al@renthouse.it", "apartamentPwdSyd", None)
        response = utente.aggiungiUtente(clientSocket)
        print("SERVER Risposta (JSON): ", json.dumps(response))
        clientSocket.close()"""

        """ELIMINA UTENTE
        clientSocket = createSocket()
        response = utente.eliminaUtente(clientSocket)
        print("SERVER Risposta (JSON): ", json.dumps(response))
        clientSocket.close()"""

        """AGGIORNA UTENTE
        utente.email = "PSherman@42Wallaby.Way"
        utente.password = "Sidney"
        clientSocket = createSocket()
        response = utente.aggiornaUtente(clientSocket)
        print("Risposta UpdateUser: ", json.dumps(response))
        clientSocket.close()"""

        """GET UTENTE BY ID
        clientSocket = createSocket()
        response = User.caricaUtenteTramiteId(138, clientSocket)
        print("Utente caricato: ", response)
        clientSocket.close()"""

        """CARICA UTENTI 
        clientSocket = createSocket()
        response = User.caricaUtenti(clientSocket)
        print("Utenti: ", response)
        clientSocket.close()"""

        """clientSocket=createSocket()
        structure = Structure("Wallaby", utente.idUser, "Sidney", "PSherman42", "Hostel", 50, None)
        response = structure.aggiungiStruttura(clientSocket)
        print("Creazione struttura: ", response)
        clientSocket.close()

        clientSocket=createSocket()
        reservation=Reservation(utente.idUser, structure.idStructure, 150, "08-04-2025", "10-04-2025", None)
        response = reservation.aggiungiPrenotazione(clientSocket)
        print("Creazione prenotazione: ", response)
        clientSocket.close()"""


    except Exception as e:
        print("Errore durante la creazione del socket: ", e)