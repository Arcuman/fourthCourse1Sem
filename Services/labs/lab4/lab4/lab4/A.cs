using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab4
{
    public class A
    {
        public string s;
        public int k;
        public float f;

        public A() { }
        public A(string s, int k, float f)
        {
            this.s = s;
            this.k = k;
            this.f = f;
        }

        public static A operator +(A a1, A a2)
        {
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }
    }
}