using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using GeoCoordinate = System.Device.Location.GeoCoordinate;


namespace RoutingServer
{
    internal class OpenStreetMapManager
    {

        static string apiKey = "5b3ce3597851110001cf624869e78fe2819549ceacb6afe9ff09fcdb";
        static string query, url, response;

        public static (GeoCoordinate, String) GetPositionCity(string address)
        {
            try
            {
                query = "api_key=" + apiKey;
                query = query + "&" + "text=" + address;
                url = "https://api.openrouteservice.org/geocode/autocomplete";
                response = OpenStreetMapApiCall(url, query).Result;
                Response geoLocalisationDetails = JsonConvert.DeserializeObject<Response>(response);
                return (geoLocalisationDetails.getGeoCoord(), geoLocalisationDetails.getCity());
            }catch(Exception e)
            {
                return (null,null);
            }
         
        }

        public static GeoCoordinate GetPosition(string address)
        {
            try
            {
                query = "api_key=" + apiKey;
                query = query + "&" + "text=" + address;
                url = "https://api.openrouteservice.org/geocode/autocomplete";
                response = OpenStreetMapApiCall(url, query).Result;
                Response geoLocalisationDetails = JsonConvert.DeserializeObject<Response>(response);
                return (geoLocalisationDetails.getGeoCoord());
            }
            catch (Exception e)
            {
                return (null);
            }

        }


        public static string GetCity(string address)
        {
            query = "api_key=" + apiKey;
            query = query + "&" + "text=" + address;
            url = "https://api.openrouteservice.org/geocode/autocomplete";
            response = OpenStreetMapApiCall(url, query).Result;
            Response geoLocalisationDetails = JsonConvert.DeserializeObject<Response>(response);
            return geoLocalisationDetails.getCity();
        }

        public static FeatureItinary GetPath(GeoCoordinate coordinate, GeoCoordinate stationPos,
            string meansOfTransportation)
        {
            try
            {
                query = "api_key=" + apiKey;
                query = query + "&start=" + toString(coordinate) + "&end=" + toString(stationPos);
                url = "https://api.openrouteservice.org/v2/directions/" + meansOfTransportation;
                response = OpenStreetMapApiCall(url, query).Result;
                ResponseItinary resp = JsonConvert.DeserializeObject<ResponseItinary>(response);
                return resp.features[0];
            }
            catch (Exception e)
            {
                return null;
            }


        }

        static async Task<string> OpenStreetMapApiCall(string url, string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url + "?" + query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public static String toString(GeoCoordinate coordianate)
        {
            return coordianate.Longitude.ToString().Replace(',', '.') + "," +
                coordianate.Latitude.ToString().Replace(',', '.');

        }



    }
}