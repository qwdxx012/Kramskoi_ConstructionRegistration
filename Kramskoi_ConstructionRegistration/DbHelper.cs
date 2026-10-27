using System.Linq;
using Kramskoi_ConstructionRegistration.Models;

namespace Kramskoi_ConstructionRegistration
{
    internal static class DbHelper
    {
        private static ConstructionEntities _dbContext; 

        public static ConstructionEntities GetDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new ConstructionEntities();
            }
            return _dbContext;
        }

        public static bool IsLoginExists(string login)
        {
            return GetDbContext().Users.Any(u => u.Login == login);
        }

        public static int GetRoleIdByName(string roleName)
        {
            return GetDbContext().Roles.First(r => r.RoleName == roleName).RoleID;
        }

        public static void AddUser(Users newUser)
        {
            GetDbContext().Users.Add(newUser);
            GetDbContext().SaveChanges();
        }
    }
}
