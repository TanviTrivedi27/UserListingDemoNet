using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using GE = GlobalEntity;

namespace BusinessLayer
{
    public class UserBC:IUserBC
    {
        private readonly IUserDA userDA;
        public UserBC(IUserDA user)
        {
            this.userDA = user;
        }

        public async Task<List<GE::User>> GetUsers()
        {
            return await this.userDA.GetUser();
        }
        public async Task<GE::User> GetIndividualUser(int id)
        {
            return await this.userDA.GetIndividualUser(id);
        }
        public async Task<string> Save(GE::User user)
        {
            return await this.userDA.Save(user);
        }
        public async Task<string> RemoveUser(int id)
        {
            return await this.userDA.RemoveUser(id);
        }
    }
}