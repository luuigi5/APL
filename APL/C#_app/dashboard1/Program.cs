using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientSocketLib;
using dashboard1.ServerSocketLib;
namespace dashboard1
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        static Thread serverThread;
        static Thread clientThread;
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            int serverPort = 5000;

            var server = new ServerSocket(serverPort);

            // Avvia il server su un thread separato
            //server.StartServerOnThread();

            string serverHost = "host.docker.internal"; // Host del server (es. localhost)

            ClientSocket client = new ClientSocket(serverHost, serverPort);

            // Connessione al server
            client.Connect();

            // Invia un messaggio al server
            client.SendMessage("Ciao Server!");

            // Ricevi la risposta dal server
            string response = client.ReceiveMessage();

            // Chiudi la connessione
            client.Close();

            Console.WriteLine("Risposta dal server: " + response);
        }
    }
}
