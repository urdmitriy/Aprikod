using System.ComponentModel.DataAnnotations;
using TestWork.Model;

namespace TestWork.Data;

public class Game
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public Studio? Studio { get; set; }
    public List<Genre?> Genres { get; set; }

    public Game()
    {
        Studio = new Studio();
        Genres = new List<Genre?>();
    }
}
