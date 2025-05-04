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
        private FlightLogic _flightLogic;
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

            _passengerLogic = new PassengerLogic();
            _flightLogic = new FlightLogic();

            _selectedSeats = new List<Seat>();
            _totalPassengers = Convert.ToInt32(persons);
            _currentPassengerIndex = 1;

            SetFlightInfoLabel();
            UpdatePassengerLabel();
            AttachSeatButtonEvents();
        }

        // Viser info om flyvning
        private void SetFlightInfoLabel()
        {
            labelFlightInfo.Text = "From: " + _departure + "\n" +
                                   "To: " + _arrival + "\n" +
                                   "Passengers: " + _persons + "\n" +
                                   "Date: " + _date + "\n" +
                                   "Time: " + _selectedFlight.Departure.ToShortTimeString();
        }

        // Opdaterer label for hvilken passager vi er på
        private void UpdatePassengerLabel()
        {
            labelPassengerInfo.Text = "Passenger " + _currentPassengerIndex + " of " + _totalPassengers;
        }

        // Tilføjer click events til alle 1 sæde-knapper (skal implementeres videre) !!!!
        private void AttachSeatButtonEvents()
        {
            button1A.Click += SeatButton_Click;
            button1B.Click += SeatButton_Click;
            button1C.Click += SeatButton_Click;
            button1D.Click += SeatButton_Click;
            button1E.Click += SeatButton_Click;
            button1F.Click += SeatButton_Click;
        }

        // Håndterer klik på et sæde (kun sæde 1A, 1B, 1C, 1D, 1E, 1F)!!!!
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string seatName = clickedButton.Text;

            Seat newSeat = new Seat();
            newSeat.SeatName = seatName;

            _selectedSeatForCurrentPassenger = newSeat;

            MessageBox.Show("Selected seat: " + seatName + "\nClick 'Next' to continue.");
        }

        // Når brugeren klikker på "Next"
        private void buttonNext2_Click(object sender, EventArgs e)
        {
            if (_selectedSeatForCurrentPassenger == null)
            {
                MessageBox.Show("Please select a seat first.");
                return;
            }

            if (textBoxPassport.Text == "" || textBoxFirstName.Text == "" || textBoxLastName.Text == "")
            {
                MessageBox.Show("Please fill in all passenger information.");
                return;
            }

            DateTime selectedBirthDate = dateTimePickerBirth.Value;

            Passenger passenger = _passengerLogic.CreatePassenger(
                textBoxPassport.Text,
                textBoxFirstName.Text,
                textBoxLastName.Text,
                DateOnly.FromDateTime(selectedBirthDate)
            );

            _selectedSeatForCurrentPassenger.Passenger = passenger;
            _selectedSeats.Add(_selectedSeatForCurrentPassenger);

            // Fjerner knappen for de buttons der er valgt
            DisableSeatButton(_selectedSeatForCurrentPassenger.SeatName);

            // Reset for næste passager
            _selectedSeatForCurrentPassenger = null;
            ClearPassengerInputs();

            _currentPassengerIndex++;

            if (_currentPassengerIndex > _totalPassengers)
            {
                _flightLogic.SelectSeatsForFlight(_selectedFlight, _selectedSeats);
                MessageBox.Show("All passengers registered!\nProceeding to confirmation.");
                Form4 form4 = new Form4(_selectedFlight, _selectedSeats);
                form4.Show();
                this.Hide();
            }
            else
            {
                UpdatePassengerLabel();
            }
        }

        // Deaktiverer den knap som hører til det valgte sæde
        private void DisableSeatButton(string seatName)
        {
            if (seatName == "1A") button1A.Enabled = false;
            else if (seatName == "1B") button1B.Enabled = false;
            else if (seatName == "1C") button1C.Enabled = false;
            else if (seatName == "1D") button1D.Enabled = false;
            else if (seatName == "1E") button1E.Enabled = false;
            else if (seatName == "1F") button1F.Enabled = false;
        }

        // Rydder felterne i passager-input til næste passeger hvis der er flere
        private void ClearPassengerInputs()
        {
            textBoxPassport.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            dateTimePickerBirth.Value = DateTime.Today;
        }
    }
}