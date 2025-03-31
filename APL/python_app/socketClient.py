import socket
import json

#HOST = '127.0.0.1'
HOST = 'go_app'
PORT = 8091

def createSocket():
    clientSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    try:
        serverAdd = ('go_app', 8091)
        #clientSocket.connect((HOST, PORT))
        clientSocket.connect(serverAdd)
        print("Connessione al server riuscita")

        request = {
            "action": "createUser",
            "data": {
                "username": "Jhonny",
                "email": "renthouse@bnb.it",
                "password": "RentHouse"
            }
        }
        requestJson = json.dumps(request)
        clientSocket.sendall(requestJson.encode())
        
        response = clientSocket.recv(1024)
        print("SERVER Risposta: ", response.decode())

    except Exception as e:
        print("Errore durante la creazione del socket: ", e)
    finally:
        clientSocket.close()