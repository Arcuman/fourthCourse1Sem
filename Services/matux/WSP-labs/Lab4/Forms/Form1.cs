using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        WS.SimplexSoapClient client;

        public Form1()
        {
            this.client = new WS.SimplexSoapClient();
            InitializeComponent();
        }

        private void GetSum_Click_1(object sender, EventArgs e)
        {
            result.ForeColor = Color.Black;
            int val1, val2;
            if (int.TryParse(x.Text.ToString(), out val1) && int.TryParse(y.Text.ToString(), out val2))
            {
                result.Text = client.Add(val1, val2).ToString();
            }
            else
            {
                result.ForeColor = Color.Red;
                result.Text = "Error!";
            }
        }

        private void Cav_Click(object sender, EventArgs e)
        {
            var msu1 = new WS.A();
            msu1.s = s1.Text;
            msu1.k = int.Parse(i1.Text);
            msu1.f = float.Parse(d1.Text);

            var msu2 = new WS.A();
            msu2.s = s2.Text;
            msu2.k = int.Parse(i2.Text);
            msu2.f = float.Parse(d2.Text);

            var result = client.Sum(msu1, msu2);

            result_1.Text = result.s;
            result_2.Text = result.k.ToString();
            result_3.Text = result.f.ToString();
        }
    }
}
