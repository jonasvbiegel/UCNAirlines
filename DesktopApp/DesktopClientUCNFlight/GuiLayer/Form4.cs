using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClientUCNFlight.BusinesslogicLayer;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.GuiLayer
{
    public partial class Form4 : Form
    {
        private Flight _selectedFlight;
        private List<Seat> _selectedSeats;
        private BookingLogic _bookingLogic;

        public Form4(Flight selectedFlight, List<Seat> selectedSeats)
        {
            InitializeComponent();

            _selectedFlight = selectedFlight;
            _selectedSeats = selectedSeats;
            _bookingLogic = new BookingLogic();

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

        private async void buttonConfirm_Click(object sender, EventArgs e)
        {
            // Opret en booking baseret på de valgte sæder og flyvningen
            Booking booking = new Booking
            {
                Flight = _selectedFlight,
                Passengers = new List<Passenger>()
            };

            foreach (Seat seat in _selectedSeats)
            {
                if (seat.Passenger != null) // kun tilføj passagerer der har et sæde
                {
                    booking.Passengers.Add(seat.Passenger);
                }
            }

            bool bookingSaved = await _bookingLogic.SaveBooking(_selectedFlight, _selectedSeats);

            if (bookingSaved)
            {
                Form5 form5 = new Form5();
                form5.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to save booking. Please try again.");
            }
        }
    }
 }