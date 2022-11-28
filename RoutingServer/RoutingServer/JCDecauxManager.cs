using Newtonsoft.Json;
using RoutingServer.ServiceProxyCacheReference;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoutingServer
{
    internal class JCDecauxManager
    {
        public static string apiKey = "197c22569da3c20597913b5cacffd1c9626b14d4";
        static string query, url, response;

        public static List<Contract> getAllContracts()
        {

            ProxyCacheServiceClient client = new ProxyCacheServiceClient();
            Contract[] contracts = client.getAllContracts();
            return (contracts.ToList());
        }
        public static List<Station> getAllStationsByContract(string contract)
        {
            ProxyCacheServiceClient client = new ProxyCacheServiceClient();
            Station[] stations = client.getStations(contract);
            return (stations.ToList());
        }

        public static Station getStation(int stationNumber, List<Station> allStations)
        {
            try
            {
                if (allStations == null || allStations.Count == 0) return null;
                Station chosenStation = allStations[0];
                foreach (Station item in allStations)
                {
                    if (item.number == stationNumber)
                    {
                        chosenStation = item;
                        break;
                    }
                }
                return chosenStation;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Station GetNearestStation(GeoCoordinate stationCoordinates, List<Station> stations, bool depart)
        {
            try
            {
                Station closestStation = null;
                GeoCoordinate candidatePos;
                Double minDistance = double.MaxValue;

                foreach (Station item in stations)
                {
                    // Find the current station's position.
                    candidatePos = new GeoCoordinate(item.position.latitude, item.position.longitude);
                    // And compare its distance to the chosen one to see if it is closer than the current closest.
                    Double distanceToCandidate = stationCoordinates.GetDistanceTo(candidatePos);

                    if (depart)
                    {
                        if (item.totalStands.availabilities.bikes <= 0)
                            continue;
                    }
                    else
                    {
                        if (item.totalStands.capacity - item.totalStands.availabilities.bikes <= 0)
                            continue;
                    }
                    {
                        if (distanceToCandidate != 0 && distanceToCandidate < minDistance)
                        {
                            closestStation = item;
                            minDistance = distanceToCandidate;
                        }
                    }
                }
                return closestStation;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Station GetNearestStation(GeoCoordinate coord, string cityName, bool depart)
        {
            try
            {
                Station s = GetNearestStation(coord, getAllStationsByContract(cityName), depart);
                return s;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}