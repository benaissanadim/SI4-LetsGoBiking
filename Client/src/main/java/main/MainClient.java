package main;

import com.baeldung.soap.ws.client.generated.*;

public class MainClient {

    public static void main(String[] args) {
        Service1 intinary =new Service1();
        IService1 proxyIntinary= intinary.getBasicHttpBindingIService1();
        Result result = proxyIntinary.getItinary("polytech nice sophia france", "2255 route des dolines france");

         System.out.println(result.getMessage());
        System.out.println();
        double distanceTotale = 0;
        double dureeTotale = 0;

        for(FeatureItinary itinary : result.getRoutes().getValue().getFeatureItinary()){
            distanceTotale += itinary.getProperties().getValue().getSummary().getValue().getDistance();
            dureeTotale += itinary.getProperties().getValue().getSummary().getValue().getDuration();

            for(Segment segment : itinary.getProperties().getValue().getSegments().getValue().getSegment()){

                System.out.println();
                System.out.println("here are your steps ...");
                System.out.println();
                int i= 0 ;
                for(Step step : segment.getSteps().getValue().getStep()){
                    i++;
                    System.out.println("step "+ i + "  => duration = " + step.getDuration() + "s & distance = " + step.getDistance()+"m");
                    System.out.println("instruction => "+ step.getInstruction().getValue());
                    System.out.println();

                }

            }
        }
        System.out.println("Distance de l'itineraire (en m) = "+ distanceTotale);
        System.out.println("Durée de l'itineraire (en s) = "+ dureeTotale);

    }
}
