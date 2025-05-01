using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClientFlights
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("-Departure-");
            comboBox1.Items.Add("Aalborg, DK");
            comboBox1.Items.Add("Nuuk, GL");
            comboBox1.Items.Add("Ilulissat, GL");
            comboBox1.Items.Add("Kangerlussuaq, GL");

            comboBox1.SelectedIndex = 0; // Departure Airport som standard


            comboBox2.Items.Add("-Arrival-"); 
            comboBox2.Items.Add("Aalborg, DK");
            comboBox2.Items.Add("Nuuk, GL");
            comboBox2.Items.Add("Ilulissat, GL");
            comboBox2.Items.Add("Kangerlussuaq, GL");

            comboBox2.SelectedIndex = 0; // Arrival Airport som standard

            for (int i = 0; i <= 10; i++)
            {
                comboBoxPersons.Items.Add(i.ToString()); // Tilføjer antal personer (1-10)
            }

            comboBoxPersons.SelectedIndex = 0; // Viser "Vælg antal personer" som standard

            monthCalendar1.ShowToday = true; // Sikrer, at i dag er markeret
            monthCalendar1.ShowTodayCircle = true; // Viser en cirkel om dagens dato
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDeparture = comboBox1.SelectedItem.ToString();
            string selectedArrival = comboBox2.SelectedItem?.ToString();

            comboBox2.Items.Clear();
            comboBox2.Items.Add("-Arrival-");

            List<string> destinations = new List<string>
            {
                "Aalborg, DK",
                "Nuuk, GL",
                "Ilulissat, GL",
                "Kangerlussuaq, GL"
            };

            foreach (string destination in destinations)
            {
                if (destination != selectedDeparture)
                {
                    comboBox2.Items.Add(destination);
                }
            }

            // Hvis den tidligere valgte ankomst stadig findes, vælg den automatisk igen
            if (selectedArrival != null && comboBox2.Items.Contains(selectedArrival))
            {
                comboBox2.SelectedItem = selectedArrival;
            }
            else
            {
                comboBox2.SelectedIndex = 0; // Standardværdi
            }

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date < DateTime.Today)
            {
                monthCalendar1.SetDate(DateTime.Today);
            }
        }
    }
}
