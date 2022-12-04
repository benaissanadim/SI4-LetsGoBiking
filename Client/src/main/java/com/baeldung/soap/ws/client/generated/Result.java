
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour Result complex type.
 * 
 * <p>Le fragment de sch�ma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="Result"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="arrivalStation" type="{http://schemas.datacontract.org/2004/07/ProxyCacheServer}Station" minOccurs="0"/&gt;
 *         &lt;element name="departureStation" type="{http://schemas.datacontract.org/2004/07/ProxyCacheServer}Station" minOccurs="0"/&gt;
 *         &lt;element name="message" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *         &lt;element name="routes" type="{http://schemas.datacontract.org/2004/07/RoutingServer}ArrayOfFeatureItinary" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Result", propOrder = {
    "arrivalStation",
    "departureStation",
    "message",
    "routes"
})
public class Result {

    @XmlElementRef(name = "arrivalStation", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<Station> arrivalStation;
    @XmlElementRef(name = "departureStation", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<Station> departureStation;
    @XmlElementRef(name = "message", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<String> message;
    @XmlElementRef(name = "routes", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfFeatureItinary> routes;

    /**
     * Obtient la valeur de la propri�t� arrivalStation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Station }{@code >}
     *     
     */
    public JAXBElement<Station> getArrivalStation() {
        return arrivalStation;
    }

    /**
     * D�finit la valeur de la propri�t� arrivalStation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Station }{@code >}
     *     
     */
    public void setArrivalStation(JAXBElement<Station> value) {
        this.arrivalStation = value;
    }

    /**
     * Obtient la valeur de la propri�t� departureStation.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Station }{@code >}
     *     
     */
    public JAXBElement<Station> getDepartureStation() {
        return departureStation;
    }

    /**
     * D�finit la valeur de la propri�t� departureStation.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Station }{@code >}
     *     
     */
    public void setDepartureStation(JAXBElement<Station> value) {
        this.departureStation = value;
    }

    /**
     * Obtient la valeur de la propri�t� message.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getMessage() {
        return message;
    }

    /**
     * D�finit la valeur de la propri�t� message.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setMessage(JAXBElement<String> value) {
        this.message = value;
    }

    /**
     * Obtient la valeur de la propri�t� routes.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfFeatureItinary }{@code >}
     *     
     */
    public JAXBElement<ArrayOfFeatureItinary> getRoutes() {
        return routes;
    }

    /**
     * D�finit la valeur de la propri�t� routes.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfFeatureItinary }{@code >}
     *     
     */
    public void setRoutes(JAXBElement<ArrayOfFeatureItinary> value) {
        this.routes = value;
    }

}
