
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour Station complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="Station"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="contractName" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *         &lt;element name="name" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *         &lt;element name="number" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/&gt;
 *         &lt;element name="position" type="{http://schemas.datacontract.org/2004/07/ProxyCacheServer}Position" minOccurs="0"/&gt;
 *         &lt;element name="totalStands" type="{http://schemas.datacontract.org/2004/07/ProxyCacheServer}Stands" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Station", namespace = "http://schemas.datacontract.org/2004/07/ProxyCacheServer", propOrder = {
    "contractName",
    "name",
    "number",
    "position",
    "totalStands"
})
public class Station {

    @XmlElementRef(name = "contractName", namespace = "http://schemas.datacontract.org/2004/07/ProxyCacheServer", type = JAXBElement.class, required = false)
    protected JAXBElement<String> contractName;
    @XmlElementRef(name = "name", namespace = "http://schemas.datacontract.org/2004/07/ProxyCacheServer", type = JAXBElement.class, required = false)
    protected JAXBElement<String> name;
    protected Integer number;
    @XmlElementRef(name = "position", namespace = "http://schemas.datacontract.org/2004/07/ProxyCacheServer", type = JAXBElement.class, required = false)
    protected JAXBElement<Position> position;
    @XmlElementRef(name = "totalStands", namespace = "http://schemas.datacontract.org/2004/07/ProxyCacheServer", type = JAXBElement.class, required = false)
    protected JAXBElement<Stands> totalStands;

    /**
     * Obtient la valeur de la propriété contractName.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getContractName() {
        return contractName;
    }

    /**
     * Définit la valeur de la propriété contractName.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setContractName(JAXBElement<String> value) {
        this.contractName = value;
    }

    /**
     * Obtient la valeur de la propriété name.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getName() {
        return name;
    }

    /**
     * Définit la valeur de la propriété name.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setName(JAXBElement<String> value) {
        this.name = value;
    }

    /**
     * Obtient la valeur de la propriété number.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getNumber() {
        return number;
    }

    /**
     * Définit la valeur de la propriété number.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setNumber(Integer value) {
        this.number = value;
    }

    /**
     * Obtient la valeur de la propriété position.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Position }{@code >}
     *     
     */
    public JAXBElement<Position> getPosition() {
        return position;
    }

    /**
     * Définit la valeur de la propriété position.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Position }{@code >}
     *     
     */
    public void setPosition(JAXBElement<Position> value) {
        this.position = value;
    }

    /**
     * Obtient la valeur de la propriété totalStands.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link Stands }{@code >}
     *     
     */
    public JAXBElement<Stands> getTotalStands() {
        return totalStands;
    }

    /**
     * Définit la valeur de la propriété totalStands.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link Stands }{@code >}
     *     
     */
    public void setTotalStands(JAXBElement<Stands> value) {
        this.totalStands = value;
    }

}
