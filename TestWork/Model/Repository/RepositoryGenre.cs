using Microsoft.EntityFrameworkCore;
using TestWork.Data;

namespace TestWork.Model.Repository;

public class RepositoryGenre : IRepositoryGenre
{
    private readonly GamesDbContext _gamesDbContext;

    public RepositoryGenre(GamesDbContext gamesDbContext)
    {
        _gamesDbContext = gamesDbContext;
    }

    public async Task<Genre?> GetGenre(int genreId)
    {
        var genres = await _gamesDbContext.Genres.ToListAsync();
        var result = genres.FirstOrDefault(x => x.Id == genreId);
        return result;
    }

    public async Task<Genre?> GetGenre(string genreTitle)
    {
        var genres = await _gamesDbContext.Genres.ToListAsync();
        var result = genres.FirstOrDefault(x => x.Title == genreTitle);
        return result;
    }

    public async Task<List<Game>?> GetGameByGenreAsync(int genreId)
    {
        var result = await _gamesDbContext.Genres.Include(z=>z.Games).FirstOrDefaultAsync(x => x.Id == genreId);
        return result?.Games;
    }
}