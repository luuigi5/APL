"""from flask import Flask, jsonify
from socket_server import createSocket

# app = Flask(__name__)
print(f"Avvio app...")

# @app.route('/hello')
# def hello():
#     return jsonify(message="Hello from Pythonvfvf!")
def main():
    createSocket()

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)"""

from socketClient import createSocket
from socket_server import createServerSocket

import time

def main():
    print("Avvio client socket")
    # createSocket()
    createServerSocket()
    while True:
        time.sleep(10)

    """while True:
        try:
            createSocket()
        except Exception as e:
            print(f"Errore durante l'esecuzione: {e}")

        #print("Attesa prima del prossimo tentativo...")
        #time.sleep(10)"""

if __name__ == '__main__':
    main()
    # app.run(host='0.0.0.0', port=5000)
