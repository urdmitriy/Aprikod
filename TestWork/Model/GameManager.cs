using TestWork.Data;
using TestWork.Model.Repository;

namespace TestWork.Model;

public class GameManager : IRepositoryGames
{
    private readonly IRepositoryGames _repositoryGames;
    private readonly IRepositoryGenre _repositoryGenre;
    private readonly IRepositoryStudio _repositoryStudio;

    public GameManager(IRepositoryGames repositoryGames, IRepositoryGenre repositoryGenre, IRepositoryStudio repositoryStudio)
    {
        _repositoryGames = repositoryGames;
        _repositoryGenre = repositoryGenre;
        _repositoryStudio = repositoryStudio;
    }

    public async Task<int> AddAsync(Game newItem)
    {
        Game newGame = new Game();
        newGame.Title = newItem.Title;
        newGame.Genres = await GetGenresGame(newItem);
        newGame.Studio = await GetStudioGame(newItem);

        return await _repositoryGames.AddAsync(newGame);
    }

    public async Task<Game?> ReadAsync(int itemId)
    {
        return await _repositoryGames.ReadAsync(itemId);
    }

    public async Task<List<Game?>> ReadAllAsync()
    {
        return await _repositoryGames.ReadAllAsync();
    }

    public async Task<int> UpdateAsync(Game item)
    {
        Game? updateGame = await _repositoryGames.ReadAsync(item.Id);
        if (updateGame != null)
        {
            updateGame.Title = item.Title;
            updateGame.Genres = await GetGenresGame(item);
            updateGame.Studio = await GetStudioGame(item);
        }

        return await _repositoryGames.UpdateAsync(updateGame);
    }

    public async Task<int> DeleteAsync(int itemId)
    {
        return await _repositoryGames.DeleteAsync(itemId);
    }

    private async Task<List<Genre?>> GetGenresGame(Game? game)
    {
        List<Genre> genres = new List<Genre>();
        
        if (game != null && game.Genres.Any())
        {
            foreach (var genre in game.Genres)
            {
                var newGenre = await _repositoryGenre.GetGenre(genre.Id);
                if (newGenre == null) newGenre = await _repositoryGenre.GetGenre(genre.Title);
                if (newGenre != null)
                {
                    genres.Add(newGenre);
                }
                else
                {
                    genres.Add(genre);
                }
            }
        }

        return genres;
    }

    private async Task<Studio> GetStudioGame(Game? game)
    {
        
        Studio result = new Studio();
        
        if (game != null)
        {
            if (game.Studio != null)
            {
                var newStudio = await _repositoryStudio.GetStudio(game.Studio.Id);
                if (newStudio == null) newStudio = await _repositoryStudio.GetStudio(game.Studio.Title);
                if (newStudio != null)
                {
                    result = newStudio;
                }
                else
                {
                    result = game.Studio;
                }
            }
        }

        return result;
    }
}