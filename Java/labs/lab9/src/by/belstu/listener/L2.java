package by.belstu.listener;

import javax.servlet.http.HttpSessionAttributeListener;
import javax.servlet.http.HttpSessionBindingEvent;

public class L2 implements HttpSessionAttributeListener {

    public void attributeAdded(HttpSessionBindingEvent event) {
        System.out.println(
                "----------------------------------- " +
                        "Session attribute added " +
                        "-----------------------------------");
    }

    public void attributeReplaced(HttpSessionBindingEvent event) {
        System.out.println(
                "----------------------------------- " +
                        "Session attribute replaced " +
                        "-----------------------------------");
    }

    public void attributeRemoved(HttpSessionBindingEvent event) {
        System.out.println(
                "----------------------------------- " +
                        "Session attribute removed " +
                        "-----------------------------------");
    }
}
