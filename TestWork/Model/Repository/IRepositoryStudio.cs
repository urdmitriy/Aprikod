using TestWork.Data;

namespace TestWork.Model.Repository;

public interface IRepositoryStudio
{
    Task<Studio?> GetStudio(int studioId);
    Task<Studio?> GetStudio(string studioTitle);
}