using MiniApp.Dtos.RestaurantDTOs;

namespace MiniApp.Dtos.ProductDTOs;

public class GetByIdProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int CategoryId{ get; set; }
    public ICollection<GetRestaurantDto> Restaurants { get; set; }
}
