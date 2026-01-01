using MiniApp.Dtos.CategoryDTOs;
using MiniApp.Dtos.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniApp.Dtos.RestaurantDTOs;

public class GetByIdRestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Cuisine { get; set; }
    public ICollection<GetCategoryDto>? Categories { get; set; }
    public ICollection<GetProductDto>? Products { get; set; }
    public ICollection<GetStaffDto>? Staffs { get; set; }
    public ICollection<GetDiningTableDto>? DiningTables { get; set; }
}
