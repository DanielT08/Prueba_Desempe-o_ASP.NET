using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using solucion.Models;

namespace solucion.Utils
{
    public class MailersendUtils
    {
        public async void SendEmail(string useremail, DateTime quoteDate)
        {
            string url = "https://api.mailersend.com/v1/email";
            string tokenEmail = "mlsn.1fb123afe2c6d13aed287445bb557556bb303753390471412f8dc42c48fff16f";
            var emailMessage = new Email
            {
                from = new From {email = "MS_Vlh3Z0@trial-ynrw7gynw9n42k8e.mlsender.net"},
                
                to = 
                [   
                    new To{email = useremail}
                ],
                subject = "Cita Veterinario",
                text =  $"¡Estimado paciente, su cita medica se encuentra programada para el dia: {quoteDate}!",
                html =  $"¡Estimado paciente, su cita medica se encuentra programada para el dia: {quoteDate}!"
        
            };
            string jsonBody = JsonSerializer.Serialize(emailMessage);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.
                AuthenticationHeaderValue("Bearer", tokenEmail);
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Estado de la solicitud: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine($"La solicitud fallo con el codigo de estado: {response.StatusCode}");
                }
            }
        }
    }
}