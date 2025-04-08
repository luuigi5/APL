"""from flask import Flask, jsonify

app = Flask(__name__)

@app.route('/hello')
def hello():
    return jsonify(message="Hello from Pythonvfvf!")

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)"""

from socketClient import doOperation
import time

def main():
    print("Avvio client socket")
    #createSocket()
    doOperation()
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