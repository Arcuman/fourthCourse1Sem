package by.bstu.servlet;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

public class Ttt extends HttpServlet {
    @Override
    protected void service(HttpServletRequest req, HttpServletResponse res) throws IOException {
        PrintWriter printWriter = res.getWriter();
        printWriter.println(
                "<br/>surname: " + req.getParameter("surname") +
                        "<br/>lastname: " + req.getParameter("lastname") +
                        "<br/>sex: " + req.getParameter("sex")
        );
    }
}
