using Microsoft.EntityFrameworkCore;
using TestWork.Data;

namespace TestWork.Model.Repository;

public class RepositoryGames : IRepositoryGames
{
    private readonly GamesDbContext _gamesDbContext;

    public RepositoryGames(GamesDbContext gamesDbContext)
    {
        _gamesDbContext = gamesDbContext;
    }

    public async Task<int> AddAsync(Game? newItem)
    {
        _gamesDbContext.Games.Add(newItem);
        var result = await _gamesDbContext.SaveChangesAsync();
        return result;
    }

    public async Task<Game?> ReadAsync(int itemId)
    {
        var result = await _gamesDbContext.Games.Include(x=>x.Genres).Include(y=>y.Studio).ToListAsync();
        return result.FirstOrDefault(x=>x.Id == itemId);
    }

    public async Task<List<Game?>> ReadAllAsync()
    {
        return await _gamesDbContext.Games.Include(x=>x.Genres).Include(y=>y.Studio).ToListAsync();
    }

    public async Task<int> UpdateAsync(Game? item)
    {
        var game = _gamesDbContext.Games.Where((x => item != null && x.Id == item.Id)).FirstOrDefault();

        if (game != null)
        {
            game.Genres = item?.Genres;
            game.Studio = item?.Studio;
            game.Title = item?.Title;
        }

        _gamesDbContext.Games.Update(game);
        
        var result = await _gamesDbContext.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteAsync(int itemId)
    {
        var games = _gamesDbContext.Games.ToList();
        var removeGame = games.FirstOrDefault(x => x != null && x.Id == itemId);
        var result = -1;
        if (removeGame == null) return result;
        _gamesDbContext.Games.Remove(removeGame);
        result = await _gamesDbContext.SaveChangesAsync();
        return result;
    }
}