

using Newtonsoft.Json.Linq;

namespace JSON_XML_CSV_Data_Format.models
{
    internal class JsonFileFormat
    {
       // Getting the Json file from the url
        public string GetJsonFromUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error while fetching data from URL: {e.Message}");
                    return string.Empty;
                }
            }
        }

         }
}

