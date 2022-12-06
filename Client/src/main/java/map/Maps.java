package map;


import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import javax.swing.JFrame;

import com.baeldung.soap.ws.client.generated.ArrayOfdouble;
import com.baeldung.soap.ws.client.generated.FeatureItinary;
import com.baeldung.soap.ws.client.generated.Result;
import org.jxmapviewer.JXMapViewer;
import org.jxmapviewer.OSMTileFactoryInfo;
import org.jxmapviewer.painter.CompoundPainter;
import org.jxmapviewer.painter.Painter;
import org.jxmapviewer.viewer.DefaultTileFactory;
import org.jxmapviewer.viewer.DefaultWaypoint;
import org.jxmapviewer.viewer.GeoPosition;
import org.jxmapviewer.viewer.TileFactoryInfo;
import org.jxmapviewer.viewer.Waypoint;
import org.jxmapviewer.viewer.WaypointPainter;

/**
 * A simple sample application that shows
 * a OSM map of Europe containing a route with waypoints
 * @author Martin Steiger
 */
public class Maps
{
   public static void init(JXMapViewer mapViewer, Result result){
       System.out.println("here");
       Set<Waypoint> waypointsFoot = new HashSet<>();
       List<GeoPosition> track = new ArrayList<>();
       List<GeoPosition> track1 = new ArrayList<>();
       List<GeoPosition> track2 = new ArrayList<>();
       List<GeoPosition> track3 = new ArrayList<>();

       int i=0;
       GeoPosition pos = null;
       int nb =0;
       for(FeatureItinary itinary : result.getRoutes().getValue().getFeatureItinary()){
           nb++;
           for(ArrayOfdouble segment : itinary.getGeometry().getValue().getCoordinates().getValue().getArrayOfdouble()){

               pos = new GeoPosition(segment.getDouble().get(1), segment.getDouble().get(0));
               if(i==0){
                   waypointsFoot.add(new DefaultWaypoint(pos));
               }
               if(nb==1){
                   track1.add(pos);
               }
               else if(nb==2){
                   track2.add(pos);
               }else if(nb==3){
                   track3.add(pos);
               }
               track.add(pos);
               i++;
           }
       }

       waypointsFoot.add(new DefaultWaypoint(pos));

       RoutePainter routePainter1 = new RoutePainter(track1);
       RouterPainterBike routePainter2 = new RouterPainterBike(track2);
       RoutePainter routePainter3 = new RoutePainter(track3);


       // Set the focus
       mapViewer.zoomToBestFit(new HashSet<GeoPosition>(track), 0.86);

       // Create a waypoint painter that takes all the waypoints
       WaypointPainter<Waypoint> waypointPainter = new WaypointPainter<Waypoint>();
       waypointPainter.setWaypoints(waypointsFoot);



       // Create a compound painter that uses both the route-painter and the waypoint-painter
       List<Painter<JXMapViewer>> painters = new ArrayList<Painter<JXMapViewer>>();
       painters.add(routePainter1);
       painters.add(routePainter2);
       painters.add(routePainter3);
       painters.add(waypointPainter);

       CompoundPainter<JXMapViewer> painter = new CompoundPainter<JXMapViewer>(painters);
       mapViewer.setOverlayPainter(painter);
       System.out.println("nadim ben aissa");

   }
}