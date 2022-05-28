using System.ComponentModel.DataAnnotations;

namespace TestWork.Data;

public class Studio
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    [System.Text.Json.Serialization.JsonIgnore]
    public List<Game>? Games { get; set; }

    public Studio()
    {
        Games = new List<Game>();
    }
}