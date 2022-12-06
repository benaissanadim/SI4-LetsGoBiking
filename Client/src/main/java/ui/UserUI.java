package ui;

import activemq.ConsumerActiveMQ;
import com.baeldung.soap.ws.client.generated.IService1;
import com.baeldung.soap.ws.client.generated.Result;
import com.baeldung.soap.ws.client.generated.Service1;
import main.Main;

import javax.swing.*;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import static java.lang.Thread.sleep;

public class UserUI extends JFrame {
    private JPanel panel;
    private JPanel ScrollBarPanel;

    private JTextField start;
    private JTextField finish;
    private JPanel myPanel;
    private JButton button1;
    private JButton button2;
    private JTextArea textArea1;

    static Service1 intinary =new Service1();
    static IService1 proxyIntinary= intinary.getBasicHttpBindingIService1();


    public UserUI(String title) {
        super(title);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setContentPane(this.myPanel);
        this.pack();
        start.setText("marseille port");
        finish.setText("stade vélodrome marseille");

        button2.addActionListener(new ActionListener() {
            @Override public void actionPerformed(ActionEvent e) {
                Boolean verif = proxyIntinary.updateSteps();
                if(verif){
                    printSteps();
                }
                else{
                    printFinish();
                }
            }
        });

        button1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Result result = proxyIntinary.getItinary(start.getText(), finish.getText());
                System.out.println(result);
                Main.updateMap(result);
                printSteps();
            }
        });
    }
    private void printSteps(){
        try{
            ConsumerActiveMQ.start();
            sleep(1000);
            String s = ConsumerActiveMQ.getList();
            String[] s1 =  s.split("/");
            this.textArea1.setText("");
            this.textArea1.append("\n-------------------------------------------------------------------------------\n");
            for(String str :s1 )
                this.textArea1.append(str);
        }catch (Exception e){
            e.getStackTrace();
        }

    }

    public void printFinish(){
        this.textArea1.append("\n-------------------------------------------\n");
        this.textArea1.append("\nFinish");
    }
    public JPanel getMyPanel() {
        return myPanel;
    }

}
