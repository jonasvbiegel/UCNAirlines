namespace UCNAirlinesWebpage.Models
{
    public class Passenger
    {
        public string? PassportNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Baggage { get; set; } = true;
        public string SelectedSeat { get; set; }

        public Passenger()
        {

        }
        public Passenger(string firstName, string lastName, string selectedSeat) 
        { 
            FirstName = firstName;
            LastName = lastName;
            SelectedSeat = selectedSeat;
        }
    }
}
