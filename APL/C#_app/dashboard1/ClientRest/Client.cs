using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dashboard1.ClientRest{
    class Client {
        public static async Task CallApiGet(string apiUrl){
            // Indirizzo del server Python esposto sulla porta 8093
            //string apiUrl = "http://localhost:8093/api/status";

            using (HttpClient client = new HttpClient()) {
                try {
                    Console.WriteLine("Invio richiesta GET a " + apiUrl);
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Risposta ricevuta:" + responseBody);
                } catch (HttpRequestException e){
                    Console.WriteLine("Errore durante la richiesta HTTP:" + e.Message);
                } catch (Exception e) {
                    Console.WriteLine("Errore generico:" + e.Message);
                }
            }
        }

        public static async Task<string> CallApiPost(string apiUrl, string payload) {
            using (HttpClient client = new HttpClient())
            {
                try {                
                    var content = new StringContent(payload, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                } catch (HttpRequestException e){
                    Console.WriteLine("Errore durante la richiesta HTTP:" + e.Message);
                    return null;
                } catch (Exception e) {
                    Console.WriteLine("Errore generico:" + e.Message);
                    return null;
                }   
            }
        }

      
    }
}