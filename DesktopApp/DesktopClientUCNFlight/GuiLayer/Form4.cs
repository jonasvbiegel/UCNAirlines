using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.GuiLayer
{
    public partial class Form4 : Form
    {
        private Flight _selectedFlight;
        private List<Seat> _selectedSeats;

        public Form4(Flight selectedFlight, List<Seat> selectedSeats)
        {
            InitializeComponent();

            _selectedFlight = selectedFlight;
            _selectedSeats = selectedSeats;

            ShowPassengerOverview();
        }

        private void ShowPassengerOverview()
        {
            StringBuilder overview = new StringBuilder();

            overview.AppendLine("Flight from " + _selectedFlight.Route.StartDestination.AirportName +
                    " to " + _selectedFlight.Route.EndDestination.AirportName);
            overview.AppendLine("Date: " + _selectedFlight.Departure.ToShortDateString());
            overview.AppendLine("Time: " + _selectedFlight.Departure.ToShortTimeString());
            overview.AppendLine("");

            int passengerNumber = 1;

            foreach (Seat seat in _selectedSeats)
            {
                Passenger p = seat.Passenger;

                overview.AppendLine("Passenger " + passengerNumber);
                overview.AppendLine("Seat: " + seat.SeatName);
                overview.AppendLine("Name: " + p.FirstName + " " + p.LastName);
                overview.AppendLine("Passport No: " + p.PassportNo);
                overview.AppendLine("Birthdate: " + p.BirthDate.ToString("dd-MM-yyyy"));
                overview.AppendLine("----------------------------");

                passengerNumber++;
            }

            textBoxOverview.Text = overview.ToString();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Form5 bookForm = new Form5();
            bookForm.Show();
            this.Hide();
        }
    }
}
