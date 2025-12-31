namespace MiniApp.Dtos;

public class GetByIdMenuDto
{
    public int Id { get; set; }
    public ICollection<int> CategoryIds { get; set; } = null!;
    public ICollection<int> RestaurantIds { get; set; } = null!;
}
