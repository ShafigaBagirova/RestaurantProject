using MiniApp.Dtos.CategoryDTOs;
using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Dtos.MenuDTOs;

public class GetByIdMenuDto
{
    public int Id { get; set; }
    public ICollection<GetCategoryDto> Categories { get; set; } 
    public ICollection<GetRestaurantDto> Restaurants { get; set; }
}
