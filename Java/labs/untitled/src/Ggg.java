import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.util.stream.Collectors;

public class Ggg extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        System.out.println("Ggg Get");

        // Task1
//        resp.getWriter().write("param" + ": " + req.getParameter("param"));
        // end Task1

//         Task4
//         RequestDispatcher rd4 = req.getRequestDispatcher("/page.html");
//         rd4.forward(req, resp);
//         end Task4

        // Task5
//        resp.getWriter().write("output Task5 from GGG");
        // end Task5

        // Task6 при редиректе null
//        resp.getWriter().write(req.getQueryString());
        // end Task6

        // Task 7
        resp.getWriter().write("query: " + req.getQueryString());
        // end Task7
    }

//    @Override
//    protected void service(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
//        System.out.println("Ggg " + req.getMethod());
//
//        // Task2
//        String body = req.getReader().lines().collect(Collectors.joining(System.lineSeparator()));
//        resp.getWriter().write("output Task2 from Ggg: " + body);
//        // end Task2
//    }

//    @Override
//    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException {
//        System.out.println("POST Ggg");
//        String body = request.getReader().lines().collect(Collectors.joining(System.lineSeparator()));
//        response.getWriter().write(body);
//    }
}
