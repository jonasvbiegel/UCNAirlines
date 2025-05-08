using DesktopClientUCNFlight.Properties;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight
{
    public partial class Form1 : Form
    {
        private readonly AirportServiceAccess _airportServiceAccess;
        public Form1()
        {
            _airportServiceAccess = new AirportServiceAccess();
            List<string> airports = Task.Run(() => _airportServiceAccess.GetAirports()).Result;
            InitializeComponent();

            comboBoxDeparture.Items.Add("--Departure Airport");
            foreach (string airport in airports)
            {
                comboBoxDeparture.Items.Add(airport);
            }

            comboBoxDeparture.SelectedIndex = 0;
           
            ////Kalder en metode nedenunder for at registrere afrejsevalg
            comboBoxDeparture.SelectedIndexChanged += comboBoxDeparture_SelectedIndexChanged;

            for (int i = 0; i <= 10; i++)
            {
                comboBoxPersons.Items.Add(i.ToString());
            }
            comboBoxPersons.SelectedIndex = 1;

            monthCalendar1.ShowToday = true;
            monthCalendar1.ShowTodayCircle = true;
            monthCalendar1.MinDate = DateTime.Today;
        }

        //Sørger for at samme by ikke kan vælges som både afrejse og ankomst - og nulstiller hvis der vælges det samme
        private void comboBoxDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDeparture = comboBoxDeparture.SelectedItem.ToString();
            string selectedArrival = comboBoxArrival.SelectedItem?.ToString();


            
            comboBoxArrival.Items.Clear();
            comboBoxArrival.Items.Add("--Arrival Airport");

            List<string> destinations = Task.Run(() => _airportServiceAccess.GetAirports()).Result;
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
            //konverterer objektet til en læsbar streng-repræsentation
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
