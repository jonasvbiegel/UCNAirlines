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

        public Form3(string departure, string arrival, string persons, string date, Flight selectedFlight)
        {
            InitializeComponent();

            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;
            _selectedFlight = selectedFlight;

            _passengerLogic = new PassengerLogic();
            _seatLogic = new SeatLogic();

            _selectedSeats = new List<Seat>();
            _totalPassengers = Convert.ToInt32(persons);
            _currentPassengerIndex = 1;

            SetFlightInfoLabel();
            UpdatePassengerLabel();

            // Hent og vis de tilgængelige sæder asynkront
            LoadSeatsAsync();
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

        // Hent de tilgængelige sæder for flyvningen asynkront
        private async void LoadSeatsAsync()
        {
            // Hent de tilgængelige sæder asynkront fra SeatLogic
            List<Seat> availableSeats = await _seatLogic.GetSeatsForFlight(_selectedFlight.FlightId);

            // Deaktiver knapperne for de valgte sæder
            foreach (Seat seat in availableSeats)
            {
                DisableSeatButton(seat.SeatName);
            }
        }

        // Deaktiverer den knap som hører til det valgte sæde
        private void DisableSeatButton(string seatName)
        {
            // Deaktiver knappen for det valgte sæde
            if (seatName == "1A") button1A.Enabled = false;
            else if (seatName == "1B") button1B.Enabled = false;
            else if (seatName == "1C") button1C.Enabled = false;
            else if (seatName == "1D") button1D.Enabled = false;
            else if (seatName == "1E") button1E.Enabled = false;
            else if (seatName == "1F") button1F.Enabled = false;
            else if (seatName == "2A") button2A.Enabled = false;
            else if (seatName == "2B") button2B.Enabled = false;
            else if (seatName == "2C") button2C.Enabled = false;
            else if (seatName == "2D") button2D.Enabled = false;
            else if (seatName == "2E") button2E.Enabled = false;
            else if (seatName == "2F") button2F.Enabled = false;
            else if (seatName == "3A") button3A.Enabled = false;
            else if (seatName == "3B") button3B.Enabled = false;
            else if (seatName == "3C") button3C.Enabled = false;
            else if (seatName == "3D") button3D.Enabled = false;
            else if (seatName == "3E") button3E.Enabled = false;
            else if (seatName == "3F") button3F.Enabled = false;
            else if (seatName == "4A") button4A.Enabled = false;
            else if (seatName == "4B") button4B.Enabled = false;
            else if (seatName == "4C") button4C.Enabled = false;
            else if (seatName == "4D") button4D.Enabled = false;
            else if (seatName == "4E") button4E.Enabled = false;
            else if (seatName == "4F") button4F.Enabled = false;
            else if (seatName == "5A") button5A.Enabled = false;
            else if (seatName == "5B") button5B.Enabled = false;
            else if (seatName == "5C") button5C.Enabled = false;
            else if (seatName == "5D") button5D.Enabled = false;
            else if (seatName == "5E") button5E.Enabled = false;
            else if (seatName == "5F") button5F.Enabled = false;
            else if (seatName == "6A") button6A.Enabled = false;
            else if (seatName == "6B") button6B.Enabled = false;
            else if (seatName == "6C") button6C.Enabled = false;
            else if (seatName == "6D") button6D.Enabled = false;
            else if (seatName == "6E") button6E.Enabled = false;
            else if (seatName == "6F") button6F.Enabled = false;
            else if (seatName == "7A") button7A.Enabled = false;
            else if (seatName == "7B") button7B.Enabled = false;
            else if (seatName == "7C") button7C.Enabled = false;
            else if (seatName == "7D") button7D.Enabled = false;
            else if (seatName == "7E") button7E.Enabled = false;
            else if (seatName == "7F") button7F.Enabled = false;
            else if (seatName == "8A") button8A.Enabled = false;
            else if (seatName == "8B") button8B.Enabled = false;
            else if (seatName == "8C") button8C.Enabled = false;
            else if (seatName == "8D") button8D.Enabled = false;
            else if (seatName == "8E") button8E.Enabled = false;
            else if (seatName == "8F") button8F.Enabled = false;
            else if (seatName == "9A") button9A.Enabled = false;
            else if (seatName == "9B") button9B.Enabled = false;
            else if (seatName == "9C") button9C.Enabled = false;
            else if (seatName == "9D") button9D.Enabled = false;
            else if (seatName == "9E") button9E.Enabled = false;
            else if (seatName == "9F") button9F.Enabled = false;
            else if (seatName == "10A") button10A.Enabled = false;
            else if (seatName == "10B") button10B.Enabled = false;
            else if (seatName == "10C") button10C.Enabled = false;
            else if (seatName == "10D") button10D.Enabled = false;
            else if (seatName == "10E") button10E.Enabled = false;
            else if (seatName == "10F") button10F.Enabled = false;
        }

        // Håndterer klik på et sæde (kun sæder, der ikke er valgt)
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string seatName = clickedButton.Text;

            Seat newSeat = new Seat();
            newSeat.SeatName = seatName;

            _selectedSeatForCurrentPassenger = newSeat;

            MessageBox.Show("Selected seat: " + seatName + "\nClick 'Next' to continue.");
        }

        private async void buttonNext2_Click(object sender, EventArgs e)
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

            DateOnly selectedBirthDate = DateOnly.FromDateTime(dateTimePickerBirth.Value);

            // Opretter passager
            Passenger passenger = new Passenger
            {
                PassportNo = textBoxPassport.Text,
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                BirthDate = selectedBirthDate
            };

            // Tildeler passager til sæde
            _selectedSeatForCurrentPassenger.Passenger = passenger;

            // Gem passageren via PassengerLogic asynkront
            bool isPassengerCreated = await _passengerLogic.CreatePassenger(passenger);

            if (isPassengerCreated)
            {
                // Opdater sæde med passageren
                bool isSeatUpdated = await _seatLogic.UpdateSeat(_selectedSeatForCurrentPassenger);

                if (!isSeatUpdated)
                {
                    MessageBox.Show("Passenger saved, but failed to update seat. Please check backend.");
                    return;
                }

                _selectedSeats.Add(_selectedSeatForCurrentPassenger);

                // Deaktiver knappen for det valgte sæde
                DisableSeatButton(_selectedSeatForCurrentPassenger.SeatName);

                // Reset for næste passager
                _selectedSeatForCurrentPassenger = null;
                ClearPassengerInputs();

                // Opdaterer passagerens info
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
                }
            }
            else
            {
                MessageBox.Show("Failed to create passenger. Please try again.");
            }
        }

        // Rydder felterne i passager-input til næste passager
        private void ClearPassengerInputs()
        {
            textBoxPassport.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            dateTimePickerBirth.Value = DateTime.Today;
        }
    }
}