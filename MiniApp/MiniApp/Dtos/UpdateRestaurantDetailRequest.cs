namespace MiniApp.Dtos;

public class UpdateRestaurantDetailRequest
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Cuisine { get; set; }
    public string? City { get; set; }
}
