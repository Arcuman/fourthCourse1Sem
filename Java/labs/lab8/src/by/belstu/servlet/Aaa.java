package by.belstu.servlet;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class Aaa extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String res = Client.task1Post(
                "http://localhost:8080/Lab8/Bbb",
                "p1",
                "p2",
                "p3",
                "h1",
                "h2",
                "h3");

        response.setContentType("text/html");
        response.getWriter().println("<h1>Body:</h1>" + res);
    }
}
