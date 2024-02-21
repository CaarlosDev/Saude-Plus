using SaudePlus.Models;

namespace SaudePlus.Repositories.Interfaces
{
    public interface IUsersRepo
    {
        Task<List<UserModels>> SearchAllUsers();
        Task<UserModels> SearchByID (int id);
        Task<UserModels> Add (UserModels usuario, int id);
        Task<UserModels> Update (UserModels user, int id);
        Task<bool> Delete (int id);
        
    }
}
