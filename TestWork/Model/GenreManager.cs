using TestWork.Data;
using TestWork.Model.Repository;

namespace TestWork.Model;

public class GenreManager
{
    private readonly IRepositoryGenre _repositoryGenre;

    public GenreManager(IRepositoryGenre repositoryGenre)
    {
        _repositoryGenre = repositoryGenre;
    }
    
    public async Task<List<Game>?> GetGameByGenreAsync(int genreId)
    {
        return await _repositoryGenre.GetGameByGenreAsync(genreId);
    }
}