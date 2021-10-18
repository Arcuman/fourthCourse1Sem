using System;
using System.Windows.Forms;

namespace form_sum
{
    public partial class Form1 : Form
    {
        ServiceReference1.SimplexSoapClient client;

        public Form1()
        {
            this.client = new ServiceReference1.SimplexSoapClient();
            InitializeComponent();
        }

        private void cav_Click(object sender, EventArgs e)
        {
            try
            {
                var a1 = new ServiceReference1.A();
                a1.s = s1.Text;
                a1.k = int.Parse(i1.Text);
                a1.f = float.Parse(d1.Text);

                var a2 = new ServiceReference1.A();
                a2.s = s2.Text;
                a2.k = int.Parse(i2.Text);
                a2.f = float.Parse(d2.Text);

                var result = client.Sum(a1, a2);

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void result_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void result_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void d2_TextChanged(object sender, EventArgs e)
        {

        }

        private void d1_TextChanged(object sender, EventArgs e)
        {

        }

        private void i2_TextChanged(object sender, EventArgs e)
        {

        }

        private void i1_TextChanged(object sender, EventArgs e)
        {

        }

        private void s2_TextChanged(object sender, EventArgs e)
        {

        }

        private void s1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
