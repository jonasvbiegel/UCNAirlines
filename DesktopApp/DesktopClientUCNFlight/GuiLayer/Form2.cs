using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace DesktopClientUCNFlight
{
    public partial class Form2 : Form
    {
        public Form2(string departure, string arrival, string persons, string date)
        {
            InitializeComponent();
            labelInfo.Text = $"Afgang: {departure}\nAnkomst: {arrival}\nAntal personer: {persons}\nDato: {date}";

            // Kolonner: navn + bredde
            listViewFlights.Columns.Add("Airline", 180);
            listViewFlights.Columns.Add("Date", 180);
            listViewFlights.Columns.Add("Time", 180);
            listViewFlights.Columns.Add("Choose", 270);

            listViewFlights.View = View.Details;
        }
    }
}
