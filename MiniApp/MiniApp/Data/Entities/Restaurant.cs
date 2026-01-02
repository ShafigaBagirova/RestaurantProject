namespace MiniApp.Data.Entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public RestaurantDetail RestaurantDetail { get; set; } 
    public ICollection<Category> Categories { get; set; }
    public ICollection<Product> Products { get; set; }
    public int? MenuId { get; set; }
    public Menu? Menu { get; set; }
    public ICollection<Staff> Staffs { get; set; }
    public ICollection<DiningTable> DiningTables { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    }
