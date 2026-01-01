namespace MiniApp.Dtos.StaffDTOs;

public class UpdateStaffRequest
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Position { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int? Age { get; set; }
}
