namespace APIService.DTOs
{
    public class AirplaneDTO
    {
        public string? Airplane_number { get; set; }
        public string? Airline { get; set; }
        public int Capacity
        {
            get
            {
                return RowCount * ColumnCount;
            }
        }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

    }
}
