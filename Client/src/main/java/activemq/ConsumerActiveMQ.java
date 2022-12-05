package activemq;

import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;

import static java.lang.System.exit;
import static java.lang.Thread.sleep;

public class ConsumerActiveMQ {
    private static Connection connect = null;
    private static Session session = null;
    private static MessageProducer sender = null;
    public static void start(){

        try{

            javax.jms.ConnectionFactory factory;
            factory = new ActiveMQConnectionFactory("tcp://localhost:61616");
            connect = factory.createConnection();
            session = connect.createSession(false, Session.AUTO_ACKNOWLEDGE);


            Destination destination = session.createQueue("ItineraryQueue9");

            MessageConsumer consumer = session.createConsumer(destination);

            connect.start();

            consumer.setMessageListener(new MessageListener() {
                @Override public void onMessage(Message message) {
                    try {
                        if (message instanceof TextMessage textMessage) {
                            String text = textMessage.getText();
                            if(text.equals("Finished!")){
                                System.out.println();
                                System.out.println("CONGRATS ARRIVED !");
                               // exit(1);
                            }
                            if(text.equals("Another request Client!")){
                                System.out.println();
                                System.out.println(text);
                                exit(0);
                            }

                            System.out.println(text);

                        } else {
                            System.out.println("received " + message);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            });
        }catch (JMSException e) {
            e.printStackTrace();
        }

    }
}
