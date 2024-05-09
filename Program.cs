// HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;


using (var client = new HttpClient())
{

    using StringContent jsonContent = new(
       JsonSerializer.Serialize(new
       {
           id = 1,
           title = "prueba"
       }),
       Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync("https://petstore.swagger.io/v2/pet", jsonContent);
    string jsonString = await response.Content.ReadAsStringAsync();
    response.EnsureSuccessStatusCode();
    string responseBody = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine(responseBody);
}