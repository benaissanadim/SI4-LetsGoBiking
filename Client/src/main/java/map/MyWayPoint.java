package map;

import org.jxmapviewer.viewer.DefaultWaypoint;
import org.jxmapviewer.viewer.GeoPosition;

import java.awt.*;
import org.jxmapviewer.viewer.DefaultWaypoint;
import org.jxmapviewer.viewer.GeoPosition;


/**
 * A waypoint that also has a color and a label
 * @author Martin Steiger
 */
public class MyWayPoint extends DefaultWaypoint
{
    private final String label;
    private final Color color;

    /**
     * @param label the text
     * @param color the color
     * @param coord the coordinate
     */
    public MyWayPoint(String label, Color color, GeoPosition coord)
    {
        super(coord);
        this.label = "ok";
        this.color = Color.ORANGE;
    }

    /**
     * @return the label text
     */
    public String getLabel()
    {
        return label;
    }

    /**
     * @return the color
     */
    public Color getColor()
    {
        return color;
    }

}
