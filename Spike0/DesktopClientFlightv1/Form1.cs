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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNæste_Click(object sender, EventArgs e)
        {
            Form2 næsteSide = new Form2();
            næsteSide.Show();
            this.Hide(); 
            // Skjuler den første form (kan også bruge this.Close() hvis du ikke skal tilbage)
        }
    }
}
