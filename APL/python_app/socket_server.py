import socket
from socket_client import GoClient  # Modulo per comunicare con Go

def createServerSocket():

    HOST = '0.0.0.0'  # Ascolta su tutte le interfacce
    PORT = 5000

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((HOST, PORT))
        s.listen()
        print(f"Server in ascolto su {HOST}:{PORT}")
        conn, addr = s.accept()
        with conn:
            print('Connessione da', addr)
            while True:
                data = conn.recv(1024)
                if not data:
                    break
                print("Ricevuto:", data)
                conn.sendall(data)

