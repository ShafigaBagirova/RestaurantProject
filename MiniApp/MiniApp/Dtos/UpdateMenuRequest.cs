namespace MiniApp.Dtos;

public class UpdateMenuRequest
{
    public ICollection<int> CategoryIds { get; set; } = null!;
    public ICollection<int> RestaurantIds { get; set; } = null!;
}
