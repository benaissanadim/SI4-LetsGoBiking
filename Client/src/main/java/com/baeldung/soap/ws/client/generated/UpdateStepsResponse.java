
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
 * <p>Le fragment de sch�ma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="updateStepsResult" type="{http://schemas.datacontract.org/2004/07/RoutingServer}ArrayOfFeatureItinary" minOccurs="0"/&gt;
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
    "updateStepsResult"
})
@XmlRootElement(name = "updateStepsResponse", namespace = "http://tempuri.org/")
public class UpdateStepsResponse {

    @XmlElementRef(name = "updateStepsResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfFeatureItinary> updateStepsResult;

    /**
     * Obtient la valeur de la propri�t� updateStepsResult.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfFeatureItinary }{@code >}
     *     
     */
    public JAXBElement<ArrayOfFeatureItinary> getUpdateStepsResult() {
        return updateStepsResult;
    }

    /**
     * D�finit la valeur de la propri�t� updateStepsResult.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfFeatureItinary }{@code >}
     *     
     */
    public void setUpdateStepsResult(JAXBElement<ArrayOfFeatureItinary> value) {
        this.updateStepsResult = value;
    }

}
