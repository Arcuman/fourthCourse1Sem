import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;


public class Sss extends HttpServlet {
    public Sss() {
        super();

        System.out.println("constructor");
    }

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);

        System.out.println("init");
    }

    @Override
    public void destroy() {
        super.destroy();

        System.out.println("destroy");
    }

    @Override
    public void service(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
        super.service(req, res);

        res.getWriter().write("service");
        res.getWriter().write(req.getMethod());

        System.out.println("service: getServiceURI()" + req.getRequestURI());
        System.out.println("service: getServletPath()" + req.getServletPath());
        System.out.println("service: getRequestURL()" + req.getRequestURL());
    }

    public void doPost(HttpServletRequest req, HttpServletResponse res) throws IOException {
        res.getWriter().println("Sss" + req.getMethod() + "\n" +
                "First Name = " + req.getParameter("firstname") + "\n" +
                "Last Name = " + req.getParameter("lastname"));
    }

    public void doGet(HttpServletRequest req, HttpServletResponse res) throws IOException {
        System.out.println("doGet()");

        res.getWriter().println("Sss" + req.getMethod() + "\n" +
                "First Name = " + req.getParameter("firstname") + "\n" +
                "Last Name = " + req.getParameter("lastname") + "\n" +
                "getQueryString(): " + req.getQueryString());
    }
}
