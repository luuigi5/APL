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


def doOperation():
    try:
        utente = User("Sabrina", "sabsid@renthouse.it", "apartamentPwdSyd", None)
        #N.B. per ogni operazione va ricreato il Socket
        """CREA UTENTE
        clientSocket = createSocket()
        utente = User("Sabrina", "sabsid@renthouse.it", "apartamentPwdSyd", None)
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

        clientSocket=createSocket()
        structure = Structure("Wallaby", 138, "Hostel", 50)
        response = structure.aggiungiStruttura(clientSocket)
        print("Creazione struttura: ", response)
        clientSocket.close()

        clientSocket=createSocket()
        reservation=Reservation("PrenotazioneCasa", 138, structure.idStructure, 150, "08-04-2025", "10-04-2025",)
        response = reservation.aggiungiPrenotazione(clientSocket)
        print("Creazione prenotazione: ", response)
        clientSocket.close()


    except Exception as e:
        print("Errore durante la creazione del socket: ", e)