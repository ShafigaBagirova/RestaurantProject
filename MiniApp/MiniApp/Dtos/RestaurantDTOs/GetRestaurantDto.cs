using MiniApp.Dtos.CategoryDTOs;
using MiniApp.Dtos.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniApp.Dtos.RestaurantDTOs;

public class GetRestaurantDto
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int MenuId { get; set; }

    public string Address { get; set; } = null!;
    public string Cuisine { get; set; } = null!;
    public string City { get; set; } = null!;
    public ICollection<GetCategoryDto>? Categories { get; set; }
    public ICollection<GetProductDto>? Products { get; set; }
    public ICollection<GetStaffDto>? Staffs { get; set; }
    public ICollection<GetDiningTableDto>? DiningTables { get; set; }

}
