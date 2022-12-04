using System;
using System.Device.Location;
using static RoutingServer.OpenStreetMapManager;
using static RoutingServer.JCDecauxManager;
using RoutingServer.ServiceProxyCacheReference;
using Apache.NMS.ActiveMQ;
using Apache.NMS;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public List<FeatureItinary> routeSteps;

            public Result GetItinary(string location, string destination)
            {
                 
                // location = "Les Abattoirs";
                // destination = "St - Martin - du - Touch";
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
                        //return SendToQueue(result.routes);
                      
                    }

                    Console.WriteLine("searching for bike stations...");

                    Station startStation = GetNearestStation(startCoordinate, departureCity, true);
                    if (startStation is null)
                    {
                        result.message = "No stations found start => walking itinerary.";
                        Console.WriteLine("No stations found => walking itinerary.");
                        result.AddRoute(GetPath(startCoordinate, endCoordinate, "foot-walking"));
                    List<FeatureItinary> r = SendToQueue(result.routes);
                    result.routes = r;

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
                        this.routeSteps = result.routes;
                    if(routeSteps == null)
                    {
                        Console.WriteLine("null au debut");
                    }
                    else
                    {
                        Console.WriteLine("not null");
                    }
                        List<FeatureItinary> r = SendToQueue(result.routes);
                    result.routes = r;

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
                        this.routeSteps = result.routes;
                           if(this.routeSteps == null)
                    {
                        Console.WriteLine("null des le debut");
                    }

                   // SendToQueue(result.routes);
                    result.arrivalStation = endStation;
                        result.departureStation = startStation;
                    List<FeatureItinary> r = SendToQueue(result.routes);
                    result.routes = r;

                    return result;
                }
                    else
                    {
                        result.message = "Bike is useless for this itinerary.";
                        Console.WriteLine("Bike is useless for this itinerary.");
                        Console.WriteLine("Returning walking itinerary.");
                        result.AddRoute(fullWalkData);
                    List<FeatureItinary> r = SendToQueue(result.routes);
                    result.routes = r;

                    return result;

                    }

                }
                catch (Exception e)
                {
                    result.message = e.Message;
                }

            return null;

            }

            public List<FeatureItinary> updateSteps(List<FeatureItinary> routeSteps) {
            if (this.routeSteps == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine("not null");
            }
            return SendToQueue (routeSteps);


            }

            public List<FeatureItinary> SendToQueue(List<FeatureItinary> routes)
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
           // ITextMessage message = session.CreateTextMessage(routes.message);
           // producer.Send(message);

            int k=0;


            foreach (FeatureItinary itinary in routes){
                foreach (Segment segment in itinary.properties.segments)
                {
                    int i = 0;
                    foreach(Step step in segment.steps)
                    {
                        i++;
                        string instruction = "step "+i+" => "+ step.instruction + " for " + step.duration +"s for "+ step.distance+"m";
                        Console.WriteLine(instruction);
                        ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                        producer.Send(messageInstruction);
                        if (i == 10)
                        {
                            k = 1;
                            break;
                        }
                    }

                }
                k = 2;
                
                break;
            }


            Console.WriteLine("ok");
            List<FeatureItinary> routeNew = new List<FeatureItinary>();
            if (k == 1)
            {
                Console.WriteLine("ok error");

                routes[0].properties.segments[0].steps
               = routes[0].properties.segments[0].steps.GetRange(10, routes[0].properties.segments[0].steps.Count);
                routes[0].geometry.coordinates
              = routes[0].geometry.coordinates.GetRange(10, routes[0].geometry.coordinates.Count);

                return routes;
            }
           
            if (k == 2)
            {
                Console.WriteLine("ok2");

                if (routes.Count == 3 )
                {
                    Console.WriteLine("ok3");

                    string instruction = "route 1 finished";
                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    Console.WriteLine(instruction);

                    producer.Send(messageInstruction);
                    routeNew.Add(routes[1]);
                    routeNew.Add(routes[2]);
                    return routeNew;
                }
                else if (routes.Count == 2)
                {
                    Console.WriteLine("ok4");

                    string instruction = "route 2 biking finished";
                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    Console.WriteLine(instruction);
                    producer.Send(messageInstruction);
                    routeNew.Add(routes[1]);
                    return routeNew;

                }
                else if (routes.Count == 1)
                {
                    Console.WriteLine("ok4");

                    string instruction = "finished!";

                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    Console.WriteLine(instruction);
                    producer.Send(messageInstruction);
                    return null;

                }

            }

            Console.WriteLine("Message sent, check ActiveMQ web interface to confirm.");

            // Don't forget to close your session and connection when finished.
            session.Close();
            connection.Close();
            return null;

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
