using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace lab4
{
    /// <summary>
    /// Сводное описание для Simplex
    /// </summary>
    [WebService(Namespace = "http://baa/", Description = "Simplex class")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(MessageName = "Add", Description = "Sum of 2 int")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "Concat", Description = "Concatination of string and double")]
        public string Concat(string s, double d)
        {
            return s + d.ToString();
        }

        [WebMethod(MessageName = "Sum", Description = "Sum of fileds of two [A] objects. Return [A] object")]
        public A Sum(A a1, A a2)
        {
            NameValueCollection t = Context.Request.Params;
            return a1 + a2;
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "Adds", Description = "Sum of 2 int. Response JSON")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}
