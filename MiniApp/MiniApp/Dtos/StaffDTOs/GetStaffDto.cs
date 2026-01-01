using MiniApp.Data.Entities;
using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Dtos.StaffDTOs;

public class GetStaffDto
{
    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Age { get; set; }
    public ICollection<GetRestaurantDto> Restaurants { get; set; }
}
