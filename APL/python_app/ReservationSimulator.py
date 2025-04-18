import json
import websocket
#import time
import logging

# Configura il logging
#logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s - %(message)s')
logger = logging.getLogger(__name__)

WS_SERVER = "ws://go_app:8092/ws"

def onMessage(ws, message):
    """Callback eseguita quando arriva un nuovo messaggio dal server"""
    try:
        data = json.loads(message)
        #logger.info(f"Dati ricevuti: {data}")
        print(f"Dati ricevuti: {data}")
    except json.JSONDecodeError:
        logger.error(f"Errore nella decodifica JSON: {message}")

def onError(ws, error):
    """Callback eseguita in caso di errore"""
    logger.error(f"Errore nella connessione WebSocket: {error}")

def onClose(ws, close_status_code, close_msg):
    """Callback eseguita quando la connessione viene chiusa"""
    logger.warning(f"Connessione WebSocket chiusa: {close_status_code} - {close_msg}")

def onOpen(ws):
    """Callback eseguita quando la connessione viene stabilita"""
    logger.info("Connessione WebSocket stabilita")

def connectWebsocket():
    """Inizializza e avvia la connessione WebSocket"""
    #websocket.enableTrace(True)
    ws = websocket.WebSocketApp(WS_SERVER, on_open=onOpen, on_message=onMessage, on_error=onError, on_close=onClose)
    ws.run_forever()