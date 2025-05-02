using DesktopClientUCNFlight.GuiLayer;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace DesktopClientUCNFlight
{
    public partial class Form2 : Form
    {
        private readonly string _departure;
        private readonly string _arrival;
        private readonly string _persons;
        private readonly string _date;
        public Form2(string departure, string arrival, string persons, string date)
        {
            InitializeComponent();
            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;

            labelInfo.Text = $"Afgang: {_departure}\nAnkomst: {_arrival}\nAntal personer: {_persons}\nDato: {_date}";

            listViewFlights.Columns.Add("Airline", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Date", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Time", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Choose", 270, HorizontalAlignment.Center);

            listViewFlights.View = View.Details;

            LoadFlights();
        }

        private void LoadFlights()
        {
            FlightServiceAccess service = new FlightServiceAccess();

            DateTime selectedDate;
            if (!DateTime.TryParse(_date, out selectedDate))
            {
                MessageBox.Show("Ugyldigt datoformat");
                return;
            }

            listViewFlights.Items.Clear(); // ryd tidligere indhold
            listViewFlights.Font = new Font("Segoe UI", 14); // lille tekst i rækker

            List<Flight> flights = service.GetFlightsByDate(selectedDate);

            if (flights == null || flights.Count == 0)
            {
                // Justér kolonner midlertidigt
                listViewFlights.Columns[0].Width = listViewFlights.Width - 4; // Fyld hele bredden
                listViewFlights.Columns[1].Width = 0;
                listViewFlights.Columns[2].Width = 0;
                listViewFlights.Columns[3].Width = 0;

                ListViewItem noFlightItem = new ListViewItem("No flights available on this date");
                listViewFlights.Items.Add(noFlightItem);

                return;
            }

            foreach (Flight flight in flights)
            {
                string airlineName = "Unknown";
                if (flight.Airplane != null && flight.Airplane.Airline != null)
                {
                    airlineName = flight.Airplane.Airline;
                }

                ListViewItem item = new ListViewItem(airlineName);
                item.SubItems.Add(flight.Departure.ToShortDateString());
                item.SubItems.Add(flight.Departure.ToShortTimeString());
                item.SubItems.Add(""); // tom "choose"-kolonne
                item.Tag = flight;

                listViewFlights.Items.Add(item);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void buttonNext2_Click(object sender, EventArgs e)
        {
            if (listViewFlights.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a flight before continuing.");
                return;
            }

            ListViewItem selectedItem = listViewFlights.SelectedItems[0];
            Flight selectedFlight = selectedItem.Tag as Flight;

            if (selectedFlight == null)
            {
                MessageBox.Show("Invalid flight selection.");
                return;
            }

            // Åbn næste form og send info videre – fx Form3
            Form3 nextForm = new Form3(_departure, _arrival, _persons, _date, selectedFlight);
            nextForm.Show();
            this.Hide(); // eller this.Close(); hvis du ikke skal vende tilbage
        }


    }
}
