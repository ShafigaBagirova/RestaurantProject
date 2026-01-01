namespace MiniApp.Data.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public int GuestCount { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int DiningTableId { get; set; }
    public DiningTable DiningTable { get; set; }
}
