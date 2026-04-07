using Fiscalizator.FiscalizationClasses.Dto.Pagination;
using Fiscalizator.FiscalizationClasses.Dto.User;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.Repository.Interfaces;
using ISession = NHibernate.ISession;
namespace Fiscalizator.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session) { }
        public User GetByUserName(string username)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username == username)!;
        }
        public User GetAdminByName(string adminName)
        {
            return _session.Query<User>().FirstOrDefault(u => u.Username == adminName && u.Role == UserRole.GlobalAdmin);
        }
        public bool ExistsInClient(string userName, int clientId)
        {
            return _session.Query<User>().Any(u => u.Username == userName && u.ClientId == clientId);
        }

        public PagedData<User> SearchAdmins(UserSearchFilterDto userFilterDto)
        {
            var users = _session.Query<User>().Where(u => u.Role == UserRole.GlobalAdmin);

            if (!string.IsNullOrWhiteSpace(userFilterDto.Name))
                users = users.Where(u => u.Username.Contains(userFilterDto.Name));
            if(!string.IsNullOrWhiteSpace(userFilterDto.Email))
                users = users.Where(u => u.Email.Contains(userFilterDto.Email));

            var totalCount = users.Count();

            var filteredUsers = users.Skip((userFilterDto.Page - 1) * userFilterDto.PageSize)
                                           .Take(userFilterDto.PageSize)
                                           .ToList();
                                      
            return new PagedData<User>
            {
                TotalCount = totalCount,
                Items = filteredUsers
            };
        }
    }
}
