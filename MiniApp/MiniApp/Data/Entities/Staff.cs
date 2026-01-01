namespace MiniApp.Data.Entities;

public class Staff
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public ICollection<Restaurant> Restaurants { get; set; }
}
