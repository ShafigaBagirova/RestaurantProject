namespace MiniApp.Dtos;

public class GetMenuDto
{
    public ICollection<GetCategoryDto> Categories { get; set; }
    public ICollection<GetRestaurantDto> Restaurants { get; set; }

}
