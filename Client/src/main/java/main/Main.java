package main;

import map.*;
import com.baeldung.soap.ws.client.generated.*;
import org.jxmapviewer.JXMapViewer;
import org.jxmapviewer.OSMTileFactoryInfo;
import org.jxmapviewer.input.CenterMapListener;
import org.jxmapviewer.input.PanKeyListener;
import org.jxmapviewer.input.PanMouseInputListener;
import org.jxmapviewer.input.ZoomMouseWheelListenerCursor;
import org.jxmapviewer.viewer.*;
import ui.UserUI;

import javax.swing.*;
import javax.swing.event.MouseInputListener;
import java.awt.*;
import java.util.*;

public class Main {

    static JXMapViewer mapViewer = new JXMapViewer();

    public static void main(String[] args) {
        Main main =new Main();

        // Display the viewer in a JFrame
        JFrame frame = new JFrame("LETS GO BIKING");
        UserUI userGUI=new UserUI("UI");
        frame.add(userGUI.getMyPanel());
        frame.setLayout(new GridLayout());

        frame.add(main.mapViewer);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
        frame.setSize(1650,1080);


        // Add interactions
        HashSet<GeoPosition> set = new HashSet<>();
        set.add(new GeoPosition( 5.374363,43.301374));
        set.add(new GeoPosition(43.286971,5.382532));
        mapViewer.zoomToBestFit(set, 0.8);
        MouseInputListener mia = new PanMouseInputListener(mapViewer);
        mapViewer.addMouseListener(mia);
        mapViewer.addMouseMotionListener(mia);
        mapViewer.addMouseListener(new CenterMapListener(mapViewer));
        mapViewer.addMouseWheelListener(new ZoomMouseWheelListenerCursor(mapViewer));
        mapViewer.addKeyListener(new PanKeyListener(mapViewer));

        // Add a selection painter
        SelectionAdapter sa = new SelectionAdapter(mapViewer);
        SelectionPainter sp = new SelectionPainter(sa);
        mapViewer.addMouseListener(sa);
        mapViewer.addMouseMotionListener(sa);
        mapViewer.setOverlayPainter(sp);

        // Create a TileFactoryInfo for OpenStreetMap
        TileFactoryInfo info = new OSMTileFactoryInfo();
        DefaultTileFactory tileFactory = new DefaultTileFactory(info);
        mapViewer.setTileFactory(tileFactory);
    }
    public static void updateMap(Result result){
        Maps.init(mapViewer, result);
    }
}
