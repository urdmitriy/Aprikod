using Microsoft.EntityFrameworkCore;
using TestWork.Data;

namespace TestWork.Model.Repository;

public class RepositoryStudio : IRepositoryStudio
{
    private readonly GamesDbContext _gamesDbContext;

    public RepositoryStudio(GamesDbContext gamesDbContext)
    {
        _gamesDbContext = gamesDbContext;
    }

    public async Task<Studio?> GetStudio(int studioId)
    {
        var studios = await _gamesDbContext.Studios.ToListAsync();
        var result = studios.FirstOrDefault(x => x.Id == studioId);
        return result;
    }

    public async Task<Studio?> GetStudio(string studioTitle)
    {
        var studios = await _gamesDbContext.Studios.ToListAsync();
        var result = studios.FirstOrDefault(x => x.Title == studioTitle);
        return result;
    }
}