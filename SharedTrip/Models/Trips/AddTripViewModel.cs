namespace SharedTrip.Models.Trips
{
    public class AddTripViewModel
    {
        public string StartPoint { get; init; }
        public string EndPoint { get; init; }
        public string DepartureTime { get; init; }
        public string ImagePath { get; init; }
        public int Seats { get; init; }
        public string Description { get; init; }
    }
}
