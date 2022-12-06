using System;
using System.Device.Location;
using static RoutingServer.OpenStreetMapManager;
using static RoutingServer.JCDecauxManager;
using RoutingServer.ServiceReference1;
using Apache.NMS.ActiveMQ;
using Apache.NMS;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static RoutingServer.ProducerActiveMQ;

namespace RoutingServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public static List<FeatureItinary> routeSteps;
        public static Station depart;
        public static Station arrive;

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
                Console.WriteLine("here..."+ startCoordinate);

                String departureCity = GetCity(location);
                Console.WriteLine("here..."+ departureCity);

                GeoCoordinate endCoordinate = GetPosition(destination);
                Console.WriteLine("here..."+ endCoordinate);

                String arrivalCity = GetCity(destination);
                Console.WriteLine("here..."+ arrivalCity);



                if (startCoordinate == null || endCoordinate == null)
                    {
                        result.message = "no result found sorry";
                        //SendToQueue(result.routes);
                      
                    }

                Console.WriteLine("searching for bike stations...");

                    Station startStation = GetNearestStation(startCoordinate, departureCity, true);
                depart = startStation;
                    if (startStation is null)
                    {
                        result.message = "No stations found start => walking itinerary.";
                        Console.WriteLine("No stations found => walking itinerary.");
                        result.AddRoute(GetPath(startCoordinate, endCoordinate, "foot-walking"));
                    routeSteps = result.routes;
                    SendToQueue();


                    return result;
                }

                    Station endStation = GetNearestStation(endCoordinate, arrivalCity, false);
                arrive = endStation;
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
                        routeSteps = result.routes;
                        SendToQueue();
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
                        routeSteps = result.routes;
                        SendToQueue();
                        return result;
                    }
                    else
                    {
                        result.message = "Bike is useless for this itinerary.";

                    Console.WriteLine("Bike is useless for this itinerary.");
                        Console.WriteLine("Returning walking itinerary.");
                    Console.WriteLine(result.message);
                    result.AddRoute(fullWalkData);
                    routeSteps = result.routes;
                    SendToQueue();
                    result.message = "Bike is useless for this itinerary.";
                    Console.WriteLine(result.message);

                    return result;

                    }

                }
                catch (Exception e)
                {
                    result.message = e.Message;
                }

            return null;

            }

            public Boolean updateSteps() {
                if (!updateAvailabilities())
                  {
                    return false;
                }
                return SendToQueue ();
            }

            public bool SendToQueue()
            {

            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession();
            IDestination destination = session.GetQueue("ItineraryQueue9");
            IMessageProducer producer = session.CreateProducer(destination);
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

            int k=0;
            string instruction = "";
            foreach (FeatureItinary itinary in routeSteps){

                foreach (Segment segment in itinary.properties.segments)
                {
                    int i = 0;
                    foreach(Step step in segment.steps)
                    {
                        i++;
                        if (i == segment.steps.Count)
                        {
                            instruction = "Finally ! => " + step.instruction;
                        }
                        else
                        {
                            instruction = "step  => " + step.name + "\n\tInsctruction :" + step.instruction +
                           "\n\tDuration :" + step.duration + "s\n\tDistance :" + step.distance + "m\n";
                        }
                        ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                        producer.Send(messageInstruction);
                       // neww[0].properties.segments[0].steps.Remove(step);
                       if (i == 10 && i < segment.steps.Count)
                        {
                            k = 1;
                            break;
                        }
                    }
                    if (k == 1) break;

                }
                if (k == 1) break;
                k = 2;

                
                break;
            }

            
            List<FeatureItinary> routeNew = new List<FeatureItinary>();
            if (k == 1)
            {

                FeatureItinary featureItinary = new FeatureItinary();
                Properties properties = new Properties();
                List<Segment> segments = new List<Segment>();
                Segment segment = new Segment();
                List<Step> stepsNew = new List<Step>();
                int i = 0;

                        foreach (Step step in routeSteps[0].properties.segments[0].steps)
                        { i++;

                    if (i <= 10) continue;
                    else
                    {
                        stepsNew.Add(step);
                    }
                    }
                segment.steps = stepsNew;
                segments.Add(segment);
                properties.segments = segments;
                featureItinary.properties = properties;

                GeometryItinary geometryItinary = new GeometryItinary();
                List<List<double>> coordinates = new List<List<double>>();

                foreach (List<double> coor in routeSteps[0].geometry.coordinates)
                {
                    i++;

                    if (i <= 10) continue;
                    else
                    {
                        List<double> coordinatesNew = new List<double>();
                        coordinatesNew.Add(coor[0]);
                        coordinatesNew.Add(coor[1]);
                        coordinates.Add(new List<double>(coordinatesNew));
                    }
                }

                geometryItinary.coordinates = coordinates;
                featureItinary.geometry = geometryItinary;
                routeNew.Add(featureItinary);

                if (routeSteps.Count == 3) {

                routeNew.Add(routeSteps[1]);
                routeNew.Add(routeSteps[2]);
                routeSteps= routeNew;
                    return true;
            }
            else if (routeSteps.Count == 2)
            {
                routeNew.Add(routeSteps[1]);
                routeSteps= routeNew;
                    return true;


            }
            else if (routeSteps.Count == 1)
            {
                routeSteps= routeNew;
                    return true;
            }
            }
           
            if (k == 2)
            {

                if (routeSteps.Count == 3) { 
                

                    instruction = "route 1 finished \n";
                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    producer.Send(messageInstruction);
                    routeNew.Add(routeSteps[1]);
                    routeNew.Add(routeSteps[2]);
                    routeSteps = routeNew;
                    return true;
                }
                else if (routeSteps.Count == 2)
                {
                    instruction = "route 2 biking finished \n";
                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    producer.Send(messageInstruction);
                    routeNew.Add(routeSteps[1]);
                    routeSteps = routeNew;
                    return true;
                }
                else if (routeSteps.Count == 1)
                {

                    instruction = "Finished!";
                    ITextMessage messageInstruction = session.CreateTextMessage(instruction);
                    Console.WriteLine(instruction);
                    producer.Send(messageInstruction);
                    return false;

                }

            }
            
            session.Close();
            connection.Close();
            return false;

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

        private Boolean updateAvailabilities()
        {

            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);
            IConnection connection = connectionFactory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession();
            IDestination destination = session.GetQueue("ItineraryQueue9");
            IMessageProducer producer = session.CreateProducer(destination);
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;
            bool verif = true;
            String instruction = "";
            if (routeSteps.Count == 3)
            {
                if (depart.totalStands.availabilities.bikes < 0)
                {
                    instruction = "no bike available at depart station !";
                    verif = false;
                }
                else
                {
                    instruction = "still bike available at depart station !\n";
                    verif = true;
                }
                if (arrive.totalStands.capacity - arrive.totalStands.availabilities.bikes <= 0)
                {
                    instruction = "no place available for your bike at arrival station !";
                    verif = false;
                  
                }
                else
                {
                    instruction = "still place available at arrival station !\n";
                }
            }

            else if (routeSteps.Count == 2)
            {
                if (arrive.totalStands.capacity - arrive.totalStands.availabilities.bikes <= 0)
                {
                    instruction = "no place available for your bike at arrival station !";
                    verif = false;

                }
                else
                {
                    instruction = "still place available at arrival station !";
                    verif = true;
                }
            }
            ITextMessage messageInstruction = session.CreateTextMessage(instruction);
            producer.Send(messageInstruction);
            if (!verif)
            {
                messageInstruction = session.CreateTextMessage("Another request Client!");
                producer.Send(messageInstruction);
            }
            session.Close();
            connection.Close();
            return verif;

        }

    }

}
