
"""@app.route('/hello')
def hello():
    return jsonify(message="Hello from Pythonvfvf!")

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)"""

from socketClient import doOperation
from ReservationSimulator import connectWebsocket
from flask import Flask, request, jsonify
import time
import threading

app = Flask(__name__)

#thread operazioni db con Go
def dbOperationThread():
    print("Avvio server db GO")
    doOperation()
    while True:
        time.sleep(60)

#thread simulazione prenotazioni con Go
def reservationSimulatorThread():
    print("Avvio server simulazioni prenotazione")
    connectWebsocket()
    while True:
        time.sleep(60)

#endpoint richiamato dal frontend
@app.route('/api/status', methods=['GET'])
def statusServer():
    return jsonify({"status": "online", "message":"Il server è pronto a rispondere"})

def startServerRest():
    app.run(host='0.0.0.0', port=8093, debug=False,use_reloader=False)


def main():
    #Avvio i vari thread
    """t1= threading.Thread(target=dbOperationThread)
    t1.daemon = True
    t1.start()

    t2 = threading.Thread(target=reservationSimulatorThread)
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