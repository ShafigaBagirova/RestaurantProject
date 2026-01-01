namespace MiniApp.Data.Entities;

public class Menu
{
    public int Id { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Restaurant> Restaurants { get; set; }
    public ICollection<Product> Products { get; set; }
}
