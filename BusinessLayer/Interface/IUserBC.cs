using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = GlobalEntity;

namespace BusinessLayer.Interface
{
    public interface IUserBC
    {
        Task<List<GE::User>> GetUsers();
        Task<GE::User> GetIndividualUser(int id);
        Task<string> Save(GE::User user);
        Task<string> RemoveUser(int id);
    }
}
