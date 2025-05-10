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
        private List<Passenger> _selectedPassengers;
        private BookingLogic _bookingLogic;
        private PassengerLogic _passengerLogic;
        private SeatLogic _seatLogic;

        public Form4(Flight selectedFlight, List<Seat> selectedSeats, List<Passenger> passengers)
        {
            InitializeComponent();

            _selectedFlight = selectedFlight;
            _selectedSeats = selectedSeats;
            _selectedPassengers = passengers;
            _bookingLogic = new BookingLogic();
            _passengerLogic = new PassengerLogic();
            _seatLogic = new SeatLogic();

            ShowPassengerOverview();
        }

        private void ShowPassengerOverview()
        {
            StringBuilder overview = new StringBuilder();

            overview.AppendLine("Flight from " + _selectedFlight.Route.StartDestination.AirportName +
                                " to " + _selectedFlight.Route.EndDestination.AirportName);
            overview.AppendLine("Date: " + _selectedFlight.Departure_time_and_date.ToShortDateString());
            overview.AppendLine("Time: " + _selectedFlight.Departure_time_and_date.ToShortTimeString());
            overview.AppendLine();

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
            foreach (Seat seat in _selectedSeats)
            {
                if (seat.Passenger == null)
                {
                    MessageBox.Show("Missing passenger information for seat: " + seat.SeatName);
                    return;
                }

                bool passengerSaved = await _passengerLogic.CreatePassenger(seat.Passenger);
                if (!passengerSaved)
                {
                    MessageBox.Show($"Failed to save passenger for seat {seat.SeatName}");
                    return;
                }
            }

            foreach (Seat seat in _selectedSeats)
            {
                bool seatUpdated = await _seatLogic.UpdateSeat(seat);
                if (!seatUpdated)
                {
                    MessageBox.Show($"Passenger saved, but failed to update seat {seat.SeatName}");
                    return;
                }
            }

            Booking booking = new Booking
            {
                Flight = _selectedFlight,
                //extracts all passengers from the selected seats, filters out any that are null, and stores the result as a list of passengers
                Passengers = _selectedSeats.Select(s => s.Passenger).Where(p => p != null).ToList()!
            };

            bool bookingSaved = await _bookingLogic.SaveBooking(booking);
            if (!bookingSaved)
            {
                MessageBox.Show("Failed to save booking. Please try again.");
                return;
            }

            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}