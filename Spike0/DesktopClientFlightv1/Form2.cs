using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClientFlightv1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 forside = new Form1();
            forside.Show();
            this.Close(); // Lukker denne form
        }

        private void BtnNæste2_Click(object sender, EventArgs e)
        {
            Form3 næsteSide = new Form3();
            næsteSide.Show();
            this.Hide();
        }
    }
}
