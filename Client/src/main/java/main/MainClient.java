package main;

import com.baeldung.soap.ws.client.generated.*;

import javax.jms.*;

import org.apache.activemq.ActiveMQConnection;
import org.apache.activemq.ActiveMQConnectionFactory;

public class MainClient{

    private static javax.jms.Connection connect = null;
    private static javax.jms.Session receiveSession = null;
    private static javax.jms.Queue queue = null;

    private static String brokerUrl = ActiveMQConnection.DEFAULT_BROKER_URL;

    public static void main(String[] args) {

        try {    // Create a connection.
            ConnectionFactory factory;
            factory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            connect = factory.createConnection();
            receiveSession = connect.createSession(false, Session.AUTO_ACKNOWLEDGE);

            Destination destination = receiveSession.createQueue("ItineraryQueue");

            MessageConsumer consumer = receiveSession.createConsumer(destination);

            connect.start();

            consumer.setMessageListener(new MessageListener() {
                @Override
                public void onMessage(Message message) {
                    System.out.println("ok");
                    try {
                        if (message instanceof TextMessage) {
                            TextMessage textMessage = (TextMessage) message;
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
