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
    public partial class Form3 : Form
    {
        private string _departure;
        private string _arrival;
        private string _persons;
        private string _date;

        private Flight _selectedFlight;
        private PassengerLogic _passengerLogic;
        private SeatLogic _seatLogic;

        private List<Seat> _selectedSeats;
        private int _totalPassengers;
        private int _currentPassengerIndex;
        private Seat _selectedSeatForCurrentPassenger;

        private List<Seat> _occupiedSeats;

        public Form3(string departure, string arrival, string persons, string date, Flight selectedFlight)
        {
            InitializeComponent();

            // Initializing fields from Form2
            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;
            _selectedFlight = selectedFlight;

            // Initializing logic layers
            _passengerLogic = new PassengerLogic();
            _seatLogic = new SeatLogic();

            // Initializing lists and variables
            _selectedSeats = new List<Seat>();
            _occupiedSeats = new List<Seat>();
            _totalPassengers = Convert.ToInt32(persons);
            _currentPassengerIndex = 1;

            // Displaying flight info
            SetFlightInfoLabel();
            UpdatePassengerLabel();
            getAvailableSeats();
        }

        // Setting the flight info in the UI
        private void SetFlightInfoLabel()
        {
            labelFlightInfo.Text = "From: " + _departure + "\n" +
                                   "To: " + _arrival + "\n" +
                                   "Passengers: " + _persons + "\n" +
                                   "Date: " + _date + "\n" +
                                   "Time: " + _selectedFlight.Departure_time_and_date.ToShortTimeString() + "\n" +
                                   "Id:" + _selectedFlight.flightId;
        }

        // Updating passenger label
        private void UpdatePassengerLabel()
        {
            labelPassengerInfo.Text = "Passenger " + _currentPassengerIndex + " of " + _totalPassengers;
        }

        private void getAvailableSeats()
        {
            comboBoxSelectSeat.Items.Add("-- Select a Seat --");

            List<Seat> seats = Task.Run(() => _seatLogic.GetSeatsForFlight(_selectedFlight.flightId)).Result;
            if (seats != null)
            {
                foreach (Seat seat in seats)
                {
                    comboBoxSelectSeat.Items.Add(seat.SeatName);

                    if (seat.Passenger == null)
                    {
                        comboBoxSelectSeat.Items.Add(seat);
                    }
                }
            }

            comboBoxSelectSeat.SelectedIndex = 0;
        }

        // Handle next button click for passenger registration
        private async void buttonNext2_Click(object sender, EventArgs e)
        {
            if (_selectedSeatForCurrentPassenger == null)
            {
                MessageBox.Show("Please select a seat first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPassport.Text) ||
                string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Please fill in all passenger information.");
                return;
            }

            var birthDate = DateOnly.FromDateTime(dateTimePickerBirth.Value);

            // Create new passenger object
            Passenger passenger = new Passenger
            {
                PassportNo = textBoxPassport.Text,
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                BirthDate = birthDate
            };

            // Assign passenger to selected seat
            _selectedSeatForCurrentPassenger.Passenger = passenger;

            // Temporarily save passenger (without updating DB yet)
            _selectedSeats.Add(_selectedSeatForCurrentPassenger);

            // Reset the selected seat
            _selectedSeatForCurrentPassenger = null;

            // Clear input fields
            ClearPassengerInputs();

            // Move to the next passenger
            _currentPassengerIndex++;

            // Check if all passengers are registered
            if (_currentPassengerIndex > _totalPassengers)
            {
                MessageBox.Show("All passengers registered!\nProceeding to confirmation.");
                Form4 form4 = new Form4(_selectedFlight, _selectedSeats);
                form4.Show();
                this.Hide();
            }
            else
            {
                // Update passenger label for the next passenger
                UpdatePassengerLabel();
            }
        }

        // Clear the input fields after registering a passenger
        private void ClearPassengerInputs()
        {
            textBoxPassport.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            dateTimePickerBirth.Value = DateTime.Today;
        }
    }
}