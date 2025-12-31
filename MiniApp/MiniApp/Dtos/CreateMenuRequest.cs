namespace MiniApp.Dtos;

public class CreateMenuRequest
{
    public ICollection<int> CategoryIds { get; set; } = null!;
    public ICollection<int> RestaurantIds { get; set; } = null!;

}
