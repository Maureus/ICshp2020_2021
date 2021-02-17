using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=60.10&lon=9.58
            // need to find latitude and longitude of 
            // http://open.mapquestapi.com/geocoding/v1/address?key=KEY&location=Washington,DC
            try
            {
                var reqClient = new WebClient();

                string key = "05oLr2hLJ3w3hQPmMkEXbKJkj2r3BOAB";
                var location = Console.ReadLine();
                if (location.Length == 0)
                {
                    throw new ArgumentException("Location cant be empty.", "location");
                }

                var responseLocation = reqClient.DownloadString(
                    $"http://open.mapquestapi.com/geocoding/v1/address?key={key}&location={location}");
                var joResponseLatLng = JObject.Parse(responseLocation);
                var latLng = (JObject) joResponseLatLng["results"][0]["locations"][0]["latLng"];
                string latitude = latLng["lat"].ToString();
                string longitude = latLng["lng"].ToString();
                Console.WriteLine($"{location} - lat: {latitude}, lng: {longitude}.");

                reqClient.Headers.Add("User-Agent", "curl/7.64.1");
                string weatherApi =
                    $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={latitude.Substring(0, 5)}&lon={longitude.Substring(0, 5)}";
                var responseWeather = reqClient.DownloadString(weatherApi);
                var joRespWeather = JObject.Parse(responseWeather);
                var joWeather = (JObject) joRespWeather["properties"]["timeseries"][0];
                string time = joWeather["time"].ToString();
                string temp = joWeather["data"]["instant"]["details"]["air_temperature"].ToString();
                string cond = joWeather["data"]["next_12_hours"]["summary"]["symbol_code"].ToString();
                Console.WriteLine($"Weather in {location} updated at {time}: temp:{temp}, cond:{cond}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}