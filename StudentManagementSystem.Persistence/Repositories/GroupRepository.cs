using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain;
using StudentManagementSystem.Persistence.Data;

namespace StudentManagementSystem.Persistence.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}   