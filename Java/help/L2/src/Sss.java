import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class Sss extends HttpServlet {
    public void init(ServletConfig sc) throws ServletException{
        super.init();
        System.out.println("Sss: init");
    }

    public void destroy(){
        super.destroy();
        System.out.println("Sss: destroy");
    }

    protected void service(HttpServletRequest rq, HttpServletResponse rs) throws ServletException, IOException {
        System.out.println("Sss: service " + rq.getMethod());

        PrintWriter pw = rs.getWriter();
        pw.println(
                "<html><body>" +
                        "<h1>Sss service " + rq.getMethod() + "</h1>" +
                        "<h3>ServerName: " + rq.getServerName() + "</h3>" +
                        "<h3>LocalAddr: " + rq.getLocalAddr() + "</h3>" +
                        "</body></html>"
        );
        String method = rq.getMethod();
        if (method.equals("GET")) {
            doGet(rq, rs);
        } else if (method.equals("POST")) {
            doPost(rq, rs);
        }
    }

    protected void doPost(HttpServletRequest rq, HttpServletResponse rs) throws ServletException, IOException {
        rs.setContentType("text/html");
        PrintWriter pw = rs.getWriter();
        pw.println(
                "<html><body>" +
                        "<h1>Sss " + rq.getMethod() + "</h1>" +
                        "<br>FirstName = " + rq.getParameter("firstname") +
                        "<br>LastName = " + rq.getParameter("lastname") +
                        "</body></html>"
        );
        pw.close();
    }

    protected void doGet(HttpServletRequest rq, HttpServletResponse rs) throws ServletException, IOException {
        rs.setContentType("text/html");
        PrintWriter pw = rs.getWriter();
        pw.println(
                "<html><body>" +
                        "<h1>Sss " + rq.getMethod() + "</h1>" +
                        "<br>FirstName = " + rq.getParameter("firstname") +
                        "<br>LastName = " + rq.getParameter("lastname") +
                        "<br>getRemoteHost: " + rq.getQueryString() +
                        "</body></html>"
        );
        pw.close();
    }
}