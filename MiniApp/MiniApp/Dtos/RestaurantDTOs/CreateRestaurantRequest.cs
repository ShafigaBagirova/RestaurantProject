namespace MiniApp.Dtos.RestaurantDTOs;

public class CreateRestaurantRequest
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Cuisine { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int MenuId { get; set; }
}