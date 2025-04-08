import zmq

class GoClient:
    def __init__(self, address="tcp://localhost:5555"):
        self.context = zmq.Context()
        self.socket = self.context.socket(zmq.REQ)
        self.socket.connect(address)

    def send_request(self, message: str):
        self.socket.send_string(message)
        response = self.socket.recv_string()
        return response