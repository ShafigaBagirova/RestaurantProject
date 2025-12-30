namespace MiniApp.Dtos;

public class CreateRestaurantDetailRequest
{
    public string Address { get; set; } = null!;
    public string Cuisine { get; set; } = null!;
    public string City { get; set; } = null!;
    public int RestaurantId { get; set; }
}
