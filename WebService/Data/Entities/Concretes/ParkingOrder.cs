using System;

public class ParkingOrder : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public int ParkingCenterId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalPriceWithTax { get; set; }
}