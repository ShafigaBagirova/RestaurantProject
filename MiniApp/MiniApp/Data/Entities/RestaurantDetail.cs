namespace MiniApp.Data.Entities;

public class RestaurantDetail
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Cuisine { get; set; }
    public string City { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
 }
