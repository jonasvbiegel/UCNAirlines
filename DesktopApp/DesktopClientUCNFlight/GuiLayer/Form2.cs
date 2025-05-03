using DesktopClientUCNFlight.BusinesslogicLayer;
using DesktopClientUCNFlight.GuiLayer;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace DesktopClientUCNFlight
{
    public partial class Form2 : Form
    {
        private readonly FlightLogic _flightLogic;

        private readonly string _departure;
        private readonly string _arrival;
        private readonly string _persons;
        private readonly string _date;

        public Form2(string departure, string arrival, string persons, string date)
        {
            InitializeComponent();

            _flightLogic = new FlightLogic();

            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;

            labelInfo.Text = "From: " + _departure + "\nTo: " + _arrival + "\nPassengers: " + _persons + "\nDate: " + _date;

            InitializeListView(); // Initialize list view layout
            LoadFlights(); // Load flights data
        }

        private void InitializeListView()
        {
            listViewFlights.Columns.Add("Airline", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Date", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Time", 180, HorizontalAlignment.Center);
            listViewFlights.Columns.Add("Choose Flight", 270, HorizontalAlignment.Center);
            listViewFlights.View = View.Details;
        }

        // Load flights based on selected date
        private void LoadFlights()
        {
            DateTime selectedDate;
            bool isDateValid = DateTime.TryParse(_date, out selectedDate);

            if (isDateValid == false)
            {
                MessageBox.Show("Invalid date format");
                return;
            }

            listViewFlights.Items.Clear();
            listViewFlights.Font = new Font("Segoe UI", 14);

            List<Flight> flights = _flightLogic.GetFlightsByDate(selectedDate); // Call Business Logic

            if (flights == null || flights.Count == 0)
            {
                HandleNoFlights();
                return;
            }

            LoadFlightItems(flights); // Load flights into ListView
        }

        private void HandleNoFlights()
        {
            listViewFlights.Columns[0].Width = listViewFlights.Width - 4;
            listViewFlights.Columns[1].Width = 0;
            listViewFlights.Columns[2].Width = 0;
            listViewFlights.Columns[3].Width = 0;

            ListViewItem noFlightItem = new ListViewItem("No flights available on this date");
            listViewFlights.Items.Add(noFlightItem);
        }

        private void LoadFlightItems(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                string airlineName = "Unknown";

                if (flight.Airplane != null)
                {
                    if (flight.Airplane.Airline != null)
                    {
                        airlineName = flight.Airplane.Airline;
                    }
                }

                ListViewItem item = new ListViewItem(airlineName);
                item.SubItems.Add(flight.Departure.ToShortDateString());
                item.SubItems.Add(flight.Departure.ToShortTimeString());
                item.SubItems.Add("SELECT");
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

            Form3 nextForm = new Form3(_departure, _arrival, _persons, _date, selectedFlight);
            nextForm.Show();
            this.Hide();
        }
    }
}

