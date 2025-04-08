using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace dashboard1.ClientSocketLib
{
    public class ClientSocket
    {
        private readonly string RemoteHost;
        private readonly int RemotePort;
        private Socket InternalSocket;
        private IPEndPoint RemoteEndpoint;

        public ClientSocket(string host, int port)
        {
            RemoteHost = host;
            RemotePort = port;

            var resultBuild = Build();

            InternalSocket = resultBuild.Item1;
            RemoteEndpoint = resultBuild.Item2;

        }

        private (Socket, IPEndPoint) Build()
        {
            IPAddress remoteIPAddress = Dns.GetHostAddresses(RemoteHost)[0];
            IPEndPoint remoteServerAddress = new IPEndPoint(remoteIPAddress, RemotePort);

            var returnSocket = new Socket(remoteServerAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            return (returnSocket, remoteServerAddress);
        }

        public void Connect()
        {
            Console.WriteLine("Remote endpoint: " + RemoteEndpoint);
            InternalSocket.Connect(RemoteEndpoint);
        }

        // Metodo per inviare un messaggio al server
        public void SendMessage(string message)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                InternalSocket.Send(messageBytes);
                Console.WriteLine("Messaggio inviato: " + message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nell'invio del messaggio: " + ex.Message);
            }
        }

        // Metodo per ricevere una risposta dal server
        public string ReceiveMessage()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = InternalSocket.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Messaggio ricevuto: " + response);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nella ricezione del messaggio: " + ex.Message);
                return string.Empty;
            }
        }

        // Metodo per chiudere la connessione
        public void Close()
        {
            try
            {
                InternalSocket.Shutdown(SocketShutdown.Both);
                InternalSocket.Close();
                Console.WriteLine("Connessione chiusa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nella chiusura della connessione: " + ex.Message);
            }
        }
    }
}
