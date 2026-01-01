namespace MiniApp.Dtos;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int MenuId { get; set; }

    public string Address { get; set; } = null!;
    public string Cuisine { get; set; } = null!;
    public string City { get; set; } = null!;
}
