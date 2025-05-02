using DesktopClientUCNFlight.Properties;

namespace DesktopClientUCNFlight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxDeparture.Items.Add("Departure Airport");
            comboBoxDeparture.Items.Add("Aalborg, DK");
            comboBoxDeparture.Items.Add("Billund, DK");
            comboBoxDeparture.Items.Add("Nuuk, GL");
            comboBoxDeparture.Items.Add("Ilulissat, GL");
            comboBoxDeparture.Items.Add("Kangerlussuaq, GL");
            comboBoxDeparture.SelectedIndex = 0;

            comboBoxArrival.Items.Add("Arrival Airport");
            comboBoxArrival.Items.Add("Aalborg, DK");
            comboBoxArrival.Items.Add("Billund, DK");
            comboBoxArrival.Items.Add("Nuuk, GL");
            comboBoxArrival.Items.Add("Ilulissat, GL");
            comboBoxArrival.Items.Add("Kangerlussuaq, GL");
            comboBoxArrival.SelectedIndex = 0;

            comboBoxDeparture.SelectedIndexChanged += comboBoxDeparture_SelectedIndexChanged;

            for (int i = 0; i <= 10; i++)
            {
                comboBoxPersons.Items.Add(i.ToString());
            }
            comboBoxPersons.SelectedIndex = 0;

            monthCalendar1.ShowToday = true;
            monthCalendar1.ShowTodayCircle = true;
        }

        private void comboBoxDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDeparture = comboBoxDeparture.SelectedItem.ToString();
            string selectedArrival = comboBoxArrival.SelectedItem?.ToString();

            comboBoxArrival.Items.Clear();
            comboBoxArrival.Items.Add("Arrival Airport");

            List<string> destinations = new List<string>
            {
                "Aalborg, DK",
                "Billund, DK",
                "Nuuk, GL",
                "Ilulissat, GL",
                "Kangerlussuaq, GL"
            };

            foreach (string destination in destinations)
            {
                if (destination != selectedDeparture)
                {
                    comboBoxArrival.Items.Add(destination);
                }
            }

            if (selectedArrival != null && comboBoxArrival.Items.Contains(selectedArrival))
            {
                comboBoxArrival.SelectedItem = selectedArrival;
            }
            else
            {
                comboBoxArrival.SelectedIndex = 0;
            }
        }

        private void ButtonNext_Click_1(object sender, EventArgs e)
        {
            if (comboBoxDeparture.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a departure airport");
                return;
            }

            if (comboBoxArrival.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an arrival airport");
                return;
            }

            if (comboBoxPersons.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the number of persons");
                return;
            }

            string departure = comboBoxDeparture.SelectedItem.ToString();
            string arrival = comboBoxArrival.SelectedItem.ToString();
            string persons = comboBoxPersons.SelectedItem.ToString();
            string date = monthCalendar1.SelectionStart.ToShortDateString();


            Form2 form2 = new Form2(departure, arrival, persons, date);
            form2.Show();
            this.Hide();
        }
    }
}
