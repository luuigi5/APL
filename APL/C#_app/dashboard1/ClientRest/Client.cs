using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dashboard1.ClientRest{
    class Client {
        public static async Task<string> CallApiGet(string apiUrl, string token){
            using (HttpClient client = new HttpClient()) {
                try {
                    if (token != null && token != "")
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
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

        public static async Task<string> CallApiPost(string apiUrl, string payload, string token) {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (token != null && token != "") {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    }
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