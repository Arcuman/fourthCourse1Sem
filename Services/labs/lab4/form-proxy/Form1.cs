using System;
using System.Windows.Forms;

namespace form_proxy
{
    public partial class Form1 : Form
    {
        Simplex simplex;
        public Form1()
        {
            simplex = new Simplex();
            InitializeComponent();
        }

        private void cav_Click(object sender, EventArgs e)
        {
            try
            {
                var a1 = new A();
                a1.s = s1.Text;
                a1.k = int.Parse(i1.Text);
                a1.f = float.Parse(d1.Text);

                var a2 = new A();
                a2.s = s2.Text;
                a2.k = int.Parse(i2.Text);
                a2.f = float.Parse(d2.Text);

                var result = simplex.Sum(a1, a2);

                result_1.Text = result.s;
                result_2.Text = result.k.ToString();
                result_3.Text = result.f.ToString();
                textBox1.Text = "Good!";
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }
    }
}
