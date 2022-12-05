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
            Result result = proxyIntinary.getItinary("marseille port", "marseille centre");

          Maps.init(result);

           boolean verif = true;
            while(verif){
                try{
                    sleep(1300);
                    System.out.println("Enter DONE for next steps ");
                    sc.next();
                    System.out.println();
                    verif = proxyIntinary.updateSteps();
                }catch (Exception e){
                    System.out.println("ok");
                }
            }
    }
}
