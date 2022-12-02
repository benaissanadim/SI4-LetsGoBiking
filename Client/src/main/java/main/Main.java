package main;

import com.baeldung.soap.ws.client.generated.IService1;
import com.baeldung.soap.ws.client.generated.Result;
import com.baeldung.soap.ws.client.generated.Service1;
import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;
import javax.jms.JMSException;
import javax.jms.Message;

public class Main {
    private static Connection connect = null;
    private static Session session = null;
    private static MessageProducer sender = null;
    private static Queue queue = null;
    public static void main(String[] args) {
        try {    // Create a connection.

            javax.jms.ConnectionFactory factory;
            factory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            connect = factory.createConnection();
            session = connect.createSession(false, Session.AUTO_ACKNOWLEDGE);


            Destination destination = session.createQueue("ItineraryQueue");

            MessageConsumer consumer = session.createConsumer(destination);

            connect.start();

            consumer.setMessageListener(new MessageListener() {
                @Override public void onMessage(Message message) {
                    try {
                        if (message instanceof TextMessage) {
                            TextMessage textMessage = (TextMessage)message;
                            String text = textMessage.getText();
                            System.out.println(text);
                        } else {
                            System.out.println("received " + message);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            });

            Service1 intinary =new Service1();
            IService1 proxyIntinary= intinary.getBasicHttpBindingIService1();
            Result result = proxyIntinary.getItinary("polytech nice sophia france", "2255 route des dolines france");
            System.out.println(result.getMessage().getValue());

        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
