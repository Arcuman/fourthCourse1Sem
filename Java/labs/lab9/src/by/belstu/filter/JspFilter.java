package by.belstu.filter;

import javax.servlet.*;
import java.io.IOException;

public class JspFilter implements Filter {
    @Override
    public void init(FilterConfig filterConfig) {
        System.out.println("JspFilter init");
    }

    @Override
    public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse, FilterChain filterChain) throws IOException, ServletException {
        System.out.println("JspFilter JspFilter");
        filterChain.doFilter(servletRequest, servletResponse);
    }

    @Override
    public void destroy() {
        System.out.println("JspFilter destroy");
    }
}
