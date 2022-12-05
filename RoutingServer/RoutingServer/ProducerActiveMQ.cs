using Apache.NMS.ActiveMQ;
using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS.ActiveMQ.Commands;

namespace RoutingServer
{
    internal class ProducerActiveMQ


    {
        static Uri connecturi = new Uri("activemq:tcp://localhost:61616");
        static ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);
        static IConnection connection = connectionFactory.CreateConnection();
        public static void initConnexion(ISession session, IMessageProducer producer)
        {
            connection.Start();
            session = connection.CreateSession();
            IDestination destination = session.GetQueue("ItineraryQueue9");
            producer = session.CreateProducer(destination);
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;
        }

        public static void sendMessage(ISession session, string instruction, IMessageProducer producer)
        {
            ITextMessage messageInstruction = session.CreateTextMessage(instruction);
            Console.WriteLine("ok");
            producer.Send(messageInstruction);

        }

        public static void endConnexion(ISession session)
        {
            session.Close();
            connection.Close();
        }

        public static void sendMessageFinishRoute(ISession session, IMessageProducer producer, int i)
        {
            if (i == 3) sendMessage(session, "arrived at your depart station", producer);
            else if (i == 2) sendMessage(session, "arrived at your arrival station", producer);
            else if (i == 1) sendMessage(session, "finished!", producer);

        }
    }
}
