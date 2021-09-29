package by.belstu.listener;


import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

public class L1 implements ServletContextListener {
    public void contextInitialized(ServletContextEvent event) {
        System.out.println(
                "----------------------------------- " +
                        "context initialized " +
                        "-----------------------------------");
    }

    public void contextDestroyed(ServletContextEvent event) {
        System.out.println(
                "----------------------------------- " +
                        "context destroyed " +
                        "-----------------------------------");
    }
}