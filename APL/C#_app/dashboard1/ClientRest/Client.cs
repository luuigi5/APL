using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace dashboard1.ClientRest
{
    class Client {
        public static async Task CallApi(){
            // Indirizzo del server Python esposto sulla porta 8093
            string apiUrl = "http://localhost:8093/api/status";

            // Creazione dell'HttpClient
            using (HttpClient client = new HttpClient()) {
                try {
                    Console.WriteLine("Invio richiesta GET a " + apiUrl);
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Risposta ricevuta:");
                    Console.WriteLine(responseBody);
                } catch (HttpRequestException e){
                    Console.WriteLine("Errore durante la richiesta HTTP:");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e) {
                    Console.WriteLine("Errore generico:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}