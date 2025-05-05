from socketClient import doOperation
from ReservationSimulator import connectWebsocket
from User import User
from flask import Flask, request, jsonify
import time
import threading
import jwt


app = Flask(__name__)

#thread operazioni db con Go
def dbOperationThread():
    print("Avvio server db GO")
    #doOperation()
    while True:
        time.sleep(60)

#thread simulazione prenotazioni con Go
def reservationSimulatorThread():
    print("Avvio server simulazioni prenotazione")
    connectWebsocket()
    while True:
        time.sleep(60)

#endpoint richiamato dal frontend
"""@app.route('/api/status', methods=['GET'])
def statusServer():
    return jsonify({"status": "online", "message":"Il server è pronto a rispondere"})"""

@app.route('/login', methods=['POST'])
def login():
    payload = request.get_json()
    response = doOperation('login', payload)
    return response  

@app.route('/addStructure', methods=['POST'])
def addStructure():
    token = request.headers.get('Authorization')
    if token and verifyToken(token) is not None:
        payload = request.get_json()
        response = doOperation('addStructure', payload)
        return response
    else:   
        return {"status": 401, "error": "Token non valido"}


@app.route('/getStructureByUser', methods=['GET'])
def getStructureByUser():
    token = request.headers.get('Authorization')
    if token and verifyToken(token) is not None:
        idUser = request.args.get('idUser')
        print("Mando la richiesta con idUser:"+ idUser)
        response = doOperation('getStructureByUser', idUser)
        return response
    else:
        return {"status": 401, "error": "Token non valido"}


def startServerRest():
    app.run(host='0.0.0.0', port=8093, debug=False,use_reloader=False)



def verifyToken(token):
    try:
        if token.startswith("Bearer "):
            token = token.split("Bearer ")[1].strip()
        key = "key_Token_jwt_temporary123!"
        decodedToken = jwt.decode(token, key, algorithms=["HS256"])
        return decodedToken
    except jwt.ExpiredSignatureError:
        print("Il token è scaduto.")
        return None
    except jwt.InvalidTokenError:
        print("Il token non è valido.")
        return None



def main():
    #Avvio i vari thread
    t1= threading.Thread(target=dbOperationThread)
    t1.daemon = True
    t1.start()

    """t2 = threading.Thread(target=reservationSimulatorThread)
    t2.daemon = True
    t2.start()"""

    t3 = threading.Thread(target=startServerRest)
    t3.daemon = True
    t3.start()

    try:
        while True:
            time.sleep(30)
    except KeyboardInterrupt:
        print("Chiusura applicazione")

if __name__ == '__main__':
    main()
