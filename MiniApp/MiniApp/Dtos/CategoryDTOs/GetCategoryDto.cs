using MiniApp.Dtos.MenuDTOs;
using MiniApp.Dtos.ProductDTOs;
using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Dtos.CategoryDTOs;

public class GetCategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GetRestaurantDto> Restaurants { get; set; }
    public ICollection<GetProductDto> Products { get; set; }
    public ICollection<GetMenuDto> Menus { get; set; }
}
