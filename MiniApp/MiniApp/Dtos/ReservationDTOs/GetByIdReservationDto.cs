namespace MiniApp.Dtos.ReservationDTOs;

public class GetByIdReservationDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public int GuestCount { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int DiningTableId { get; set; }
}
