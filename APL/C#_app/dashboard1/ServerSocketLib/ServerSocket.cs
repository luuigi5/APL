using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace dashboard1.ServerSocketLib
{
    public class ServerSocket
    {
        private readonly int ServerPort;
        private Socket serversocket;

        public ServerSocket(int serverPort)
        {
            ServerPort = serverPort;
            serversocket = Build();
        }
        private Socket Build()
        {
            IPAddress iPAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(iPAddress, ServerPort);

            var socket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            socket.Bind(localEndPoint);
            socket.Listen(ServerPort);

            Console.WriteLine("Server Start: Port " + ServerPort);

            return socket;
        }

        public void Run()
        {
            try
            {
                while (true)  // Mantiene il server in ascolto in un loop infinito
                {
                    Socket acceptSocket = serversocket.Accept();  // Accetta una connessione in ingresso

                    var remoteAddress = ((IPEndPoint)acceptSocket.RemoteEndPoint).Address.ToString();
                    var remotePort = ((IPEndPoint)acceptSocket.RemoteEndPoint).Port;

                    Console.WriteLine("Nuovo Client Connesso -> " + remoteAddress + ":" + remotePort);

                    // Esegui qui le operazioni necessarie, come la lettura e l'invio di messaggi al client
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(serversocket.Connected)
                {
                    serversocket.Shutdown(SocketShutdown.Both);
                    serversocket.Close();
                }
            }
        }

        // Metodo per avviare il server su un thread separato
        public void StartServerOnThread()
        {
            // Crea un thread che esegue il metodo Run
            Thread serverThread = new Thread(new ThreadStart(Run));
            serverThread.IsBackground = true;  // Imposta il thread come in background
            serverThread.Start();  // Avvia il thread
        }
    }
}
