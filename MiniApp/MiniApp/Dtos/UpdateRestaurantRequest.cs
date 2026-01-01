namespace MiniApp.Dtos;

public class UpdateRestaurantRequest
{
    public int Id { get; set; } 
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Cuisine { get; set; }
    public string? Phone { get; set; }
    public int? MenuId { get; set; }
    public ICollection<int>? CategoryIds { get; set; }
    public ICollection<int>? ProductIds { get; set; }
    public ICollection<int>? StaffIds { get; set; }
    public ICollection<int>? DiningTableIds { get; set; }
}
