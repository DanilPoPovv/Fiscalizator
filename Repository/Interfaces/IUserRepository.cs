using Fiscalizator.FiscalizationClasses.Dto.Pagination;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;

namespace Fiscalizator.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistsInClient(string userName, int clientId);
        User GetByUserName(string username);
        PagedData<User> SearchAdmins(UserSearchFilterDto userFilterDto);
    }
}