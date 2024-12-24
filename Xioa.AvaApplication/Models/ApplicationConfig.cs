using SQLite;

namespace Xioa.AvaApplication.Models;

/// <summary>
/// @author Xioa
/// @date  2024年12月24日
/// </summary>
public class ApplicationConfig {
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string? Name { get; set; }
}