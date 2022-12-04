package main;

import activemq.ConsumerActiveMQ;
import map.*;
import com.baeldung.soap.ws.client.generated.*;

import java.util.*;

import static java.lang.Thread.sleep;

public class Main {

    static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
            ConsumerActiveMQ.start();

            Service1 intinary =new Service1();
            IService1 proxyIntinary= intinary.getBasicHttpBindingIService1();
            Result result = proxyIntinary.getItinary("polytech nice sophia", "2255 route des dolines");

            Maps.init(result);

           ArrayOfFeatureItinary array = result.getRoutes().getValue();
            while(array != null){
                try{
                    sleep(2000);
                    System.out.println("Enter DONE for next steps ");
                    sc.next();

                    System.out.println();

                    array = proxyIntinary.updateSteps(array);
                }catch (Exception e){
                    System.out.println("ok");
                }
            }

    }
}
