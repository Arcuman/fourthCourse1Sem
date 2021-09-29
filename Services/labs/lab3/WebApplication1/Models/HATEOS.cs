using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HATEOS
    {
        public string Href { get; set; }
        public string Rel { get; set; }

        public HATEOS(string href, string rel)
        {
            Href = href;
            Rel = rel;
        }
    }
}