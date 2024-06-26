using System;
using System.Text.Json;
using nsoftware.IPWorks;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the Http component
        Http http = new Http();

        // Assign the Runtime License
        http.RuntimeLicense = "31504E48415A30353235323433305745425452314131004256484B514A58584A4F4D574B4F52580030303030303030300000505335453835414D4B5642520000#IPWORKS#EXPIRING_TRIAL#20240624\n\n";


        try
        {
            // Make the GET request with the URL
            http.Get("https://dummyjson.com/products");

            // Parse the JSON response
            string jsonResponse = http.TransferredData;
            JsonDocument doc = JsonDocument.Parse(jsonResponse);
            JsonElement root = doc.RootElement;
            JsonElement products = root.GetProperty("products");

            // Iterate through the products and print the titles
            foreach (JsonElement product in products.EnumerateArray())
            {
                string title = product.GetProperty("title").GetString();
                Console.WriteLine(title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
