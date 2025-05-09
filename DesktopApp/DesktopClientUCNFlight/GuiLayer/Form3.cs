using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        private SeatLogic _seatLogic;

        private List<Seat> _availableSeats;
        private List<Seat> _selectedSeats;
        private int _totalPassengers;
        private int _currentPassengerIndex;
        private Seat _selectedSeatForCurrentPassenger;

        public Form3(string departure, string arrival, string persons, string date, Flight selectedFlight)
        {
            InitializeComponent();

            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;
            _selectedFlight = selectedFlight;

            _seatLogic = new SeatLogic();

            _selectedSeats = new List<Seat>();
            _availableSeats = new List<Seat>();
            _totalPassengers = Convert.ToInt32(persons);
            _currentPassengerIndex = 1;

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

            _availableSeats = Task.Run(() => _seatLogic.GetSeatsForFlight(_selectedFlight.flightId)).Result;
            if (_availableSeats != null)
            {
                foreach (Seat seat in _availableSeats)
                {
                    if (seat.Passenger == null)
                    {
                        comboBoxSelectSeat.Items.Add(seat.SeatName);
                    }
                }
            }

            comboBoxSelectSeat.SelectedIndex = 0;
        }

        private async void buttonNext2_Click(object sender, EventArgs e)
        {
            string selectedSeatName = comboBoxSelectSeat.SelectedItem?.ToString();
            string passportNo = textBoxPassport.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            var birthDate = DateOnly.FromDateTime(dateTimePickerBirth.Value);

            if (string.IsNullOrWhiteSpace(selectedSeatName) || selectedSeatName == "-- Select a Seat --")
            {
                MessageBox.Show("Please select a valid seat before proceeding.");
                return; 
            }

            if (InputIsOk(selectedSeatName, passportNo, firstName, lastName))
            {
                Passenger passenger = new Passenger
                {
                    PassportNo = passportNo,
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate
                };

                //Find through _availableSeats and find the first seat where SeatName matches SelectedSeatName
                Seat selectedSeat = _availableSeats.Find(s => s.SeatName == selectedSeatName);

                if (selectedSeat != null)
                {
                    selectedSeat.Passenger = passenger;
                    _selectedSeats.Add(selectedSeat);
                    comboBoxSelectSeat.Items.Remove(selectedSeatName);
                    comboBoxSelectSeat.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Error: Selected seat not found");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all passenger information and select a seat.");
                return;
            }

            _currentPassengerIndex++;
            if (_currentPassengerIndex > _totalPassengers)
            {
                MessageBox.Show("All passengers registered!\nProceeding to confirmation.");
                Form4 form4 = new Form4(_selectedFlight, _selectedSeats);
                form4.Show();
                this.Hide();
            }
            else
            {
                UpdatePassengerLabel();
                ClearPassengerInputs();
            }
        }

        private bool InputIsOk(string seat, string passportNo, string firstName, string lastName)
        {
            bool isValidInput = false;
            if (!string.IsNullOrWhiteSpace(seat) &&
                !string.IsNullOrWhiteSpace(passportNo) &&
                !string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(lastName)) {
                if (passportNo.Length > 1 && firstName.Length > 0 && lastName.Length > 0) 
                {
                    isValidInput = true;
                }
            }
            return isValidInput;
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