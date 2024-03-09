using System;

public abstract class Car : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public int ModelId { get; set; }
    public string CarNumber { get; set; }
}
