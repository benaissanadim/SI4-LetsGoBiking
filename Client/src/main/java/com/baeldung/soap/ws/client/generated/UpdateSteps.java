
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour anonymous complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
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
@XmlType(name = "", propOrder = {
    "routes"
})
@XmlRootElement(name = "updateSteps", namespace = "http://tempuri.org/")
public class UpdateSteps {

    @XmlElementRef(name = "routes", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfFeatureItinary> routes;

    /**
     * Obtient la valeur de la propriété routes.
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
     * Définit la valeur de la propriété routes.
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
