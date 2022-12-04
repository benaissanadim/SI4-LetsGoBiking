using Newtonsoft.Json;
using RoutingServer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using static RoutingServer.OpenStreetMapManager;

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
            try
            {
                ProxyCacheServiceClient client = new ProxyCacheServiceClient();
                Station[] stations = client.getStations(contract);
                return (stations.ToList());
            }catch(Exception e)
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
                  
                    if (distanceToCandidate != 0 && distanceToCandidate < minDistance)
                    {
                        closestStation = item;
                        minDistance = distanceToCandidate;
                    }
                    
                }
                return closestStation;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Contract getNearestContract(GeoCoordinate coord)
        {
            try
            {
                Contract closestContract = null;
                GeoCoordinate pos;
                Double minDistance = double.MaxValue;
                List<Contract> contracts = getAllContracts();

                foreach (Contract item in contracts)
                {

                    pos = GetPosition(item.name);
                    if (pos == null) continue;
                    Double distanceToCandidate = coord.GetDistanceTo(pos);
                    if (distanceToCandidate != 0 && distanceToCandidate < minDistance)
                    {
                        closestContract = item;
                        minDistance = distanceToCandidate;
                    }
                }
                return closestContract;
            }
            catch(Exception e)
            {
                return null;
            }
            
            
        }

        public static Station GetNearestStation(GeoCoordinate coord, string cityName, bool depart)
        {

            try
            {
                List<Station> stations = getAllStationsByContract(cityName);

                if (stations != null)
                {
                    return GetNearestStation(coord, stations, depart);
                }

                Contract closestContract = getNearestContract(coord);


                return GetNearestStation(coord, getAllStationsByContract(closestContract.name), depart);

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}