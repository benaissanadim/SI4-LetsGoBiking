using System;
using System.Device.Location;
using static RoutingServer.OpenStreetMapManager;
using static RoutingServer.JCDecauxManager;
using RoutingServer.ServiceProxyCacheReference;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
            public Result GetItinary(string location, string destination)
            {
                 //location = "Les Abattoirs toulouse france";
                 // destination = "St - Martin - du - Touch toulouse france";
                //ok
              //  location = "nice france";
               // destination = "marseile france";
                location = "nice";
                destination = "seville";
                Console.WriteLine("Finding path between {0} and {1} ...", location, destination);
                Result result = new Result();

                try
                {
                    Console.WriteLine("Retrieving coordinates...");
                    GeoCoordinate startCoordinate = GetPosition(location);
                    String departureCity = GetCity(location);
                    GeoCoordinate endCoordinate = GetPosition(destination);
                    String arrivalCity = GetCity(destination);

                    if (startCoordinate == null || endCoordinate == null)
                    {
                        result.message = "no result found sorry";
                        return null;
                    }

                    Console.WriteLine("searching for bike stations...");

                    Station startStation = GetNearestStation(startCoordinate, departureCity, true);
                    if (startStation is null)
                    {
                        result.message = "No stations found start => walking itinerary.";
                        Console.WriteLine("No stations found => walking itinerary.");
                        result.AddRoute(GetPath(startCoordinate, endCoordinate, "foot-walking"));
                        return result;
                    }

                    Station endStation = GetNearestStation(endCoordinate, arrivalCity, false);
                    if (endStation is null || startStation.Equals(endStation))
                    {
                        if (endStation is null)
                        {
                            result.message = "No stations found arrival => walking itinerary.";
                        }
                        if (startStation.Equals(endStation))
                            result.message = "same station start and arrival => walking itinerary.";
                        Console.WriteLine("walking itinerary.");
                        result.AddRoute(GetPath(startCoordinate, endCoordinate, "foot-walking"));
                        return result;
                    }

                    FeatureItinary ridingData = GetPath(toGeoCoordinate(startStation.position), toGeoCoordinate(endStation.position), "cycling-regular");

                    FeatureItinary fullWalkData = GetPath(startCoordinate, endCoordinate, "foot-walking");
                    FeatureItinary waltToStationStart = GetPath(startCoordinate, toGeoCoordinate(startStation.position), "foot-walking");
                    FeatureItinary waltFromStationEnd = GetPath(toGeoCoordinate(endStation.position), endCoordinate, "foot-walking");

                    if (CanUseBike(waltToStationStart, ridingData, waltFromStationEnd, fullWalkData))
                    {
                        result.message = "walking +  riding + walking itinerary.";

                        result.AddRoute(waltToStationStart);
                        result.AddRoute(ridingData);
                        result.AddRoute(waltFromStationEnd);
                        return result;
                    }
                    else
                    {
                        result.message = "Bike is useless for this itinerary.";
                        Console.WriteLine("Bike is useless for this itinerary.");
                        Console.WriteLine("Returning walking itinerary.");
                        result.AddRoute(fullWalkData);
                        return result;
                    }
                    return result;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                }

                return result;
            }


            private bool CanUseBike(FeatureItinary start, FeatureItinary ride, FeatureItinary end, FeatureItinary full)
            {
                double startTime = start.properties.summary.duration;
                double rideTime = ride.properties.summary.duration;
                double endTime = end.properties.summary.duration;

                return full.properties.summary.duration > startTime + rideTime + endTime;
            }

        private GeoCoordinate toGeoCoordinate(Position position)
        {
            return new GeoCoordinate(position.latitude, position.longitude);
        }

    }

    }
