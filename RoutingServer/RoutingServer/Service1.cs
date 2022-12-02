using System;
using System.Device.Location;
using static RoutingServer.OpenStreetMapManager;
using static RoutingServer.JCDecauxManager;
using RoutingServer.ServiceProxyCacheReference;
using Apache.NMS.ActiveMQ;
using Apache.NMS;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
            public Result GetItinary(string location, string destination)
            {
                 
                 location = "Les Abattoirs";
                 destination = "St - Martin - du - Touch";
                 //ok
                //location = "polytech nice sophia";
                //destination = "2255 route des dolines";
                //location = "nice";
               // destination = "seville";
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
                        sendToQueue(null);

                        return null;
                    }

                    Console.WriteLine("searching for bike stations...");

                    Station startStation = GetNearestStation(startCoordinate, departureCity, true);
                    if (startStation is null)
                    {
                        result.message = "No stations found start => walking itinerary.";
                        Console.WriteLine("No stations found => walking itinerary.");
                        result.AddRoute(GetPath(startCoordinate, endCoordinate, "foot-walking"));
                        sendToQueue(result);

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
                        sendToQueue(result);

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
                        sendToQueue(result);

                        return result;
                    }
                    else
                    {
                        result.message = "Bike is useless for this itinerary.";
                        Console.WriteLine("Bike is useless for this itinerary.");
                        Console.WriteLine("Returning walking itinerary.");
                        result.AddRoute(fullWalkData);
                        sendToQueue(result);

                        return result;
                    }

                    sendToQueue(result);
                    return result;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                }
                sendToQueue(result);

                return result;

            }

            public static void sendToQueue(Result result)
            {

            // Create a Connection Factory.
            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);

            // Create a single Connection from the Connection Factory.
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();

            // Create a session from the Connection.
            ISession session = connection.CreateSession();

            // Use the session to target a queue.
            IDestination destination = session.GetQueue("ItineraryQueue");

            // Create a Producer targetting the selected queue.
            IMessageProducer producer = session.CreateProducer(destination);

            // You may configure everything to your needs, for instance:
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

            // Finally, to send messages:
           /* foreach(FeatureItinary itinary in result.routes){
                foreach (Segment segment in itinary.properties)
                {

                }
            }*/
            ITextMessage message = session.CreateTextMessage(result.message);
            producer.Send(message);

            Console.WriteLine("Message sent, check ActiveMQ web interface to confirm.");
            Console.ReadLine();

            // Don't forget to close your session and connection when finished.
            session.Close();
            connection.Close();

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
