namespace MiniApp.Data.Entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public RestaurantDetail? RestaurantDetail { get; set; }
}
