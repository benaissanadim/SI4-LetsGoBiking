package main;

import com.baeldung.soap.ws.client.generated.ObjectFactory;

import javax.swing.*;

public class AddressPanel extends JPanel {
    protected JLabel label;
    protected JTextField street;
    protected JTextField city;
    protected JTextField country;
    protected JTextField zipcode;

    public AddressPanel(){
        this("", "", "", "");
    }

    public AddressPanel(String street, String city, String country, String zipcode){
        this.label = new JLabel("Address");
        this.street = new JTextField(street, 15);
        this.city = new JTextField(city, 10);
        this.country = new JTextField(country, 10);
        this.zipcode = new JTextField(zipcode, 6);

        this.add(this.label);
        this.add(this.street);
        this.add(this.city);
        this.add(this.country);
        this.add(this.zipcode);
    }

    public void setLabel(String label){
        this.label.setText(label);
    }
}