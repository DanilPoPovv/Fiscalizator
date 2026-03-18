using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository
{
    public interface IUserRepository
    {
        bool ExistsInClient(string userName, int clientId);
        User GetByUserName(string username);
        User GetGlobalUserByName(string userName);
    }
}