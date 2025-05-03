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
    public partial class Form3 : Form
    {
        private readonly string _departure;
        private readonly string _arrival;
        private readonly string _persons;
        private readonly string _date;
        private readonly Flight _selectedFlight;

        public Form3(string departure, string arrival, string persons, string date, Flight selectedFlight)
        {
            InitializeComponent();

            _departure = departure;
            _arrival = arrival;
            _persons = persons;
            _date = date;
            _selectedFlight = selectedFlight;

            SetFlightInfoLabel();
        }

        private void SetFlightInfoLabel()
        {
            labelFlightInfo.Text = $"From: {_departure}\n" +
                                   $"To: {_arrival}\n" +
                                   $"Passengers: {_persons}\n" +
                                   $"Date: {_date}\n" +
                                   $"Time: {_selectedFlight.Departure.ToShortTimeString()}";
        }
    }
}
