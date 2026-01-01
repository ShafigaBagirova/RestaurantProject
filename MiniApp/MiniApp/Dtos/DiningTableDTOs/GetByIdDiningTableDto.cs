using MiniApp.Dtos.ReservationDTOs;

namespace MiniApp.Dtos.DiningTableDTOs;

public class GetByIdDiningTableDto
{
    public int Id { get; set; }
    public int DiningTableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; }
    public int RestaurantId { get; set; }
    public ICollection<GetReservationDto> Reservations { get; set; }
}
