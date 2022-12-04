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
   public static void init(Result result){

       Set<Waypoint> waypoints = new HashSet<>();
       List<GeoPosition> track = new ArrayList<>();
       int i=0;
       GeoPosition pos = null;
       for(FeatureItinary itinary : result.getRoutes().getValue().getFeatureItinary()){
           for(ArrayOfdouble segment : itinary.getGeometry().getValue().getCoordinates().getValue().getArrayOfdouble()){

               pos = new GeoPosition(segment.getDouble().get(1), segment.getDouble().get(0));
               if(i==0){
                   waypoints.add(new DefaultWaypoint(pos));
               }
               track.add(pos);
               i++;
           }

       }

       waypoints.add(new DefaultWaypoint(pos));

       JXMapViewer mapViewer = new JXMapViewer();

       // Display the viewer in a JFrame
       JFrame frame = new JFrame("JXMapviewer2 Example 2");
       frame.getContentPane().add(mapViewer);
       frame.setSize(800, 600);
       frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
       frame.setVisible(true);

       // Create a TileFactoryInfo for OpenStreetMap
       TileFactoryInfo info = new OSMTileFactoryInfo();
       DefaultTileFactory tileFactory = new DefaultTileFactory(info);
       mapViewer.setTileFactory(tileFactory);

       RoutePainter routePainter = new RoutePainter(track);

       // Set the focus
       mapViewer.zoomToBestFit(new HashSet<GeoPosition>(track), 0.7);

       // Create a waypoint painter that takes all the waypoints
       WaypointPainter<Waypoint> waypointPainter = new WaypointPainter<Waypoint>();
       waypointPainter.setWaypoints(waypoints);

       // Create a compound painter that uses both the route-painter and the waypoint-painter
       List<Painter<JXMapViewer>> painters = new ArrayList<Painter<JXMapViewer>>();
       painters.add(routePainter);
       painters.add(waypointPainter);

       CompoundPainter<JXMapViewer> painter = new CompoundPainter<JXMapViewer>(painters);
       mapViewer.setOverlayPainter(painter);

   }
}