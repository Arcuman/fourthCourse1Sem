﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace WebApplication1
{
    public class DeleteHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var req = context.Request;
            HttpResponse res = context.Response;

            res.ContentType = "application/json";
            res.AppendHeader("Access-Control-Allow-Origin", "*");
            res.AppendHeader("Access-Control-Allow-Credentials", "true");
            res.AppendHeader("Access-Control-Allow-Methods", "*");

            try
            {
                var SessionData = (string)context.Session["SessionData"];

                dynamic data = JObject.Parse(SessionData);
                int result = Convert.ToInt32(data.result);
                var array = data.stack;
                int[] newArray = ((Newtonsoft.Json.Linq.JArray)array).Select(item => (int)item).ToArray();
                Stack<int> stack = new Stack<int>(new int[] { });
                foreach (int i in newArray.Reverse())
                {
                    stack.Push(Convert.ToInt32(i));
                }
                if(stack.Count > 0)
                {
                    stack.Pop();
                }
                
                context.Session["SessionData"] = js.Serialize(new
                {
                    result = result,
                    stack = stack
                });
                var response = js.Serialize(new
                {
                    status = "Success",
                    result = result,
                    stack = stack
                });
                res.Write(response);
            }
            catch (InvalidOperationException)
            {
                res.Write(js.Serialize(new { status = "Failed" }));
            };
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}