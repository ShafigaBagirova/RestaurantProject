namespace MiniApp.Dtos;

public class CreateRestaurantRequest
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Cuisine { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int? MenuId { get; set; }
    public ICollection<int>? CategoryIds { get; set; }
    public ICollection<int>? ProductIds { get; set; }
    public ICollection<int>? StaffIds { get; set; }
    public ICollection<int>? DiningTableIds { get; set; }
}