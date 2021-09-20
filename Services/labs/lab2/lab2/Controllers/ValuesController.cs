using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace lab2.Controllers
{
    
    public class ValuesController : ApiController
    {
        public object Get()
        {
            int top;
            if (Result.stack.TryPeek(out top))
                return new { result = Result.result + top, stack = Result.stack };
            else
                return new { result = Result.result, stack = "Stack is empty" };
        }

        [HttpPost]
        public object Post([FromUri] string result)
        {
            int number;
            if (int.TryParse(result, out number))
            {
                Result.result = number;
                int top;
                if (Result.stack.TryPeek(out top))
                    return new { result = Result.result + top, stack = Result.stack };
                else
                    return new { result = Result.result, stack = "Stack is empty" };
            }
            else
                return new { error = new { message = "Type of Params is not Integer", result = result } };
        }

        [HttpPut]
        public object Put([FromUri] string add)
        {
            int number;
            if (int.TryParse(add, out number))
            {
                Result.stack.Push(number);
                int top;
                if (Result.stack.TryPeek(out top))
                    return new { result = Result.result + top, stack = Result.stack };
                else
                    return new { result = Result.result, stack = "Stack is empty" };
            }
            else
                return new { error = new { message = "Type of Params is not Integer", result = add } };
        }

        [HttpDelete]
        public object Delete()
        {
            int top;
            if (Result.stack.TryPop(out top) && Result.stack.TryPeek(out top))
                return new { result = Result.result + top, stack = Result.stack };
            else
                return new { result = Result.result, stack = "Stack is empty" };
        }
    }
}
