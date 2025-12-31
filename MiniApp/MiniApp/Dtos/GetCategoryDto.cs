namespace MiniApp.Dtos;

public class GetCategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GetProductDto> Products { get; set; }
    public ICollection<GetRestaurantDto> Restaurants { get; set; }
}
