public class ParkingCenter : BaseEntity<int>
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Name { get; set; }
    public decimal PricePerHour { get; set; }
    public short AvailableSlots { get; set; }
    public short TotalSlots { get; set; }
}
