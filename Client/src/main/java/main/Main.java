package main;

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
            System.out.println("ok");

            javax.jms.ConnectionFactory factory;
            System.out.println("ok");

            factory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            System.out.println("ok");

            connect = factory.createConnection();
            System.out.println("ok");

            session = connect.createSession(false, Session.AUTO_ACKNOWLEDGE);
            System.out.println("ok");


            Destination destination = session.createQueue("ItineraryQueue");

            MessageConsumer consumer = session.createConsumer(destination);

            connect.start();

            consumer.setMessageListener(new MessageListener() {
                @Override public void onMessage(Message message) {
                    try {
                        if (message instanceof TextMessage) {
                            TextMessage textMessage = (TextMessage)message;
                            String text = textMessage.getText();
                            System.out.println("recieved " + text);
                        } else {
                            System.out.println("received " + message);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            });
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
