package by.belstu.filter;

import javax.servlet.*;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;

import java.io.IOException;

public class F2 implements Filter {
    @Override
    public void init(FilterConfig filterConfig) {
        System.out.println("F2 init");
    }

    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException {
        System.out.println("do Filter2");

        String value = servletRequest.getParameter("f2");
        if (value == null) {
            servletResponse.getWriter().println("Ccc blocked on F2");
        } else {
            System.out.printf("do Filter2 good: %s \n", value);
            filterChain.doFilter(servletRequest, servletResponse);
        }
    }

    @Override
    public void destroy() {
        System.out.println("F2 destroy");
    }
}
