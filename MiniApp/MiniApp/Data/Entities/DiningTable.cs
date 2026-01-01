namespace MiniApp.Data.Entities;

public class DiningTable
{
    public int Id { get; set; }
    public int DiningTableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}
