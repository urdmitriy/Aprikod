using TestWork.Data;

namespace TestWork.Model.Repository;

public interface IRepositoryGenre
{
    Task<Genre?> GetGenre(int genreId);
    Task<Genre?> GetGenre(string genreTitle);

    Task<List<Game>?> GetGameByGenreAsync(int genreId);
}