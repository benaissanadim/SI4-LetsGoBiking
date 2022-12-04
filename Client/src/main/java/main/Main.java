package main;

import com.baeldung.soap.ws.client.generated.ArrayOfFeatureItinary;
import com.baeldung.soap.ws.client.generated.IService1;
import com.baeldung.soap.ws.client.generated.Result;
import com.baeldung.soap.ws.client.generated.Service1;
import org.apache.activemq.ActiveMQConnectionFactory;

import javax.jms.*;
import javax.jms.JMSException;
import javax.jms.Message;

import java.util.Scanner;

import static java.lang.System.exit;
import static java.lang.Thread.sleep;

public class Main {
    private static Connection connect = null;
    private static Session session = null;
    private static MessageProducer sender = null;
    private static Queue queue = null;
    static Scanner sc = new Scanner(System.in);

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
                            sleep(500);
                            String text = textMessage.getText();
                            if(text.equals("finished!")){
                                System.out.println();
                                System.out.println("CONGRATS ARRIVED !");
                              //  exit(1);
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

            Service1 intinary =new Service1();
            IService1 proxyIntinary= intinary.getBasicHttpBindingIService1();
            Result result = proxyIntinary.getItinary("Marseille centre", "marseille port");
            System.out.println(result.getMessage().getValue());
            ArrayOfFeatureItinary array = result.getRoutes().getValue();
            while(array != null){
                try{
                    sleep(1000);
                    System.out.println();
                    sc.next();
                    System.out.println();

                    array = proxyIntinary.updateSteps(array);
                }catch (Exception e){
                    System.out.println("ok");
                }
            }
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
