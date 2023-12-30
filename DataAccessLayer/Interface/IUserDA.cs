using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace DataAccessLayer.Interface
{
    public interface IUserDA
    {
        Task<List<GE::User>> GetUser();
        Task<GE::User> GetIndividualUser(int id);
        Task<string> Save(GE::User user);
        Task<string> RemoveUser(int id);
    }
}
