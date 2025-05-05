using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Data
{
    public class PassengerData
    {
        public static List<Passenger> PassengerList = new List<Passenger>
        {
            new Passenger { PassportNo = "P12345", FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1985, 4, 15) },
            new Passenger { PassportNo = "P67890", FirstName = "Jane", LastName = "Smith", BirthDate = new DateOnly(1990, 8, 22) },
            new Passenger { PassportNo = "P11223", FirstName = "Michael", LastName = "Johnson", BirthDate = new DateOnly(1995, 2, 10) },
        };

        // Create
        public static void Create(Passenger passenger)
        {
            PassengerList.Add(passenger);
        }
    }
}
