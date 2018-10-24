using System;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OpenWeatherMap");
            Console.WriteLine("Please enter the zip code of the area you want to know the temperature in.\nE.g., 12345");

            string jsonFromSettingsFile = File.ReadAllText("appsettings.development.json");
            string AccessID = JObject.Parse(jsonFromSettingsFile)["AccessID"].ToString();

            while (true)
            {
                Console.WriteLine("Enter zip");
                WebClient webClient = new WebClient();
                string zip = Console.ReadLine();
                string response = webClient.DownloadString("http://api.openweathermap.org/data/2.5/weather?zip=" + zip + AccessID);
                JObject jo = JObject.Parse(response);
                JToken degreesKelvin = jo.GetValue("main")["temp"];

                Console.WriteLine(degreesKelvin);
            }
        }
    }
}
