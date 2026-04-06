using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistsInClient(string userName, int clientId);
        User GetByUserName(string username);
        
    }
}