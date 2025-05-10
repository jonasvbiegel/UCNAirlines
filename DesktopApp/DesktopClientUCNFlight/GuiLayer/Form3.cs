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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace DesktopClientUCNFlight.GuiLayer
{
    public partial class Form3 : Form
    {
        private string _departure;
        private string _arrival;
        private string _persons;
        private string _date;
        private List<Button> _btns=new List<Button>();
        private Flight _selectedFlight;
        private SeatLogic _seatLogic;
        private List<Seat> _updateSeats;
        private List<Seat> _selectedSeats;
        private int _totalPassengers;
        private int _currentPassengerIndex;
        private Seat _selectedSeatForCurrentPassenger;
        private List<Button> _selectedButtons;
        
        public Form3(string departure, string arrival, string persons, string date, Flight selectedFlight)
        {
            InitializeComponent();
            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;
            _selectedFlight = selectedFlight;
            _selectedButtons = new List<Button>();
            _seatLogic = new SeatLogic();
            tableLayoutPanel1.RowCount = _selectedFlight.Airplane.SeatRows;
            tableLayoutPanel1.ColumnCount = _selectedFlight.Airplane.SeatColumns;
            _selectedSeats = new List<Seat>();
            _updateSeats = new List<Seat>();
            _totalPassengers = Convert.ToInt32(persons);
            _currentPassengerIndex = 1;

            SetFlightInfoLabel();
            UpdatePassengerLabel();
            GetAvailableSeats();
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

        
        private List<Button> GetAvailableSeats()
        {


            List<Seat> seats = Task.Run(() => _seatLogic.GetSeatsForFlight(_selectedFlight.flightId)).Result;
            if (seats != null)
            {
                foreach (Seat seat in seats)
                {

                    Button button = new()
                    {
                        Text = seat.SeatName,
                        AutoSize = true,

                    };
                    if (seat.Passenger?.PassportNo == null)
                    {
                        button.Enabled = true;
                        button.BackColor = Color.LightGreen; 
                    }
                    else
                    {
                        button.Enabled = false;
                        button.BackColor = Color.LightGray; 
                    }
                    _selectedSeats.Add(seat);
                    button.Click+= SeatButton_Click;
                    _btns.Add(button);
                    tableLayoutPanel1.Controls.Add(button);
                }

            }
            
            return _btns;
        }

        private void SeatButton_Click(object sender,EventArgs e) 
        {   
            Button clickedButton = sender as Button;
            //clickedButton.Enabled = false;
            string seatName = clickedButton.Text;
            foreach(Seat s in _selectedSeats)
            {
                if(s.SeatName.Equals(seatName))
                {
                    _selectedSeatForCurrentPassenger = s;
                    _selectedButtons.Add(clickedButton);
                } 
            }
            
        }
        private async void buttonNext2_Click(object sender, EventArgs e)
        {
            string selectedSeatName = _selectedSeatForCurrentPassenger.SeatName;
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

                
                    _selectedSeatForCurrentPassenger.Passenger = passenger;
                    _updateSeats.Add(_selectedSeatForCurrentPassenger);
              
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
                Form4 form4 = new Form4(_selectedFlight, _updateSeats );
                form4.Show();
                this.Hide();
            }
            else
            {
                foreach(Button btn in _selectedButtons)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
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