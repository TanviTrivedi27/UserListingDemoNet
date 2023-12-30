using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using GE = GlobalEntity;

namespace DataAccessLayer
{
    public class UserDA:IUserDA
    {
        private readonly User_DBContext user_DBContext;
        public UserDA(User_DBContext user_DBContext)
        {

            this.user_DBContext = user_DBContext;

        }   
        public async Task<List<GE::User>> GetUser()
        {
           var _data=await this.user_DBContext.User.ToListAsync();
            List<GE::User> Users= new List<GE::User>();
            if (_data != null)
            {
                _data.ForEach(item => {
                    Users.Add(new GE.User()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Mobile = item.Mobile,
                        CreatedDate = item.CreatedDate,
                        DOB=item.DOB,
                        Gender = item.Gender,
                        Skills = item.Skills,
                        Subscribe=item.Subscribe,
                        Year=item.Year,
                       
                    });
                });
            }
            return Users;
        }

        public async Task<GE::User> GetIndividualUser(int id)
        {
            var _data = await this.user_DBContext.User.FirstOrDefaultAsync(item=>item.Id==id);
            GE::User users = new GE.User();
            if (_data != null)
            {
               
                    users=(new GE.User()
                    {
                        Id = _data.Id,
                        FirstName = _data.FirstName,
                        LastName = _data.LastName,
                        Email = _data.Email,
                        Mobile = _data.Mobile,
                        DOB=_data.DOB,
                        CreatedDate = _data.CreatedDate,
                        Gender=_data.Gender,
                        Skills=_data.Skills,
                        Subscribe = _data.Subscribe,
                        Year = _data.Year,

                    });
             
            }
            return users;
        }

        public async Task<string> Save(GE::User user)
        {
            string Response = string.Empty;
            try
            {
                if(user.Id>0)
                {
                    var _exist= await this.user_DBContext.User.FirstOrDefaultAsync(item => item.Id == user.Id);
                    if(_exist != null)
                    {
                        _exist.Id = user.Id;
                        _exist.FirstName = user.FirstName;
                        _exist.LastName = user.LastName;
                        _exist.Email = user.Email;
                        _exist.Mobile = user.Mobile;
                        _exist.CreatedDate = user.CreatedDate;
                        _exist.DOB = user.DOB;
                        _exist.Skills = user.Skills;
                        _exist.Gender = user.Gender;
                        _exist.Subscribe = user.Subscribe;
                        _exist.Year = user.Year;

                    }
                }
                else
                {
                    User user1 = new User()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Mobile = user.Mobile,
                        CreatedDate = user.CreatedDate,
                        DOB = user.DOB,
                        Skills = user.Skills,
                        Gender = user.Gender,
                        Subscribe = user.Subscribe,
                        Year = user.Year,




                    };
                   await this.user_DBContext.User.AddAsync(user1);
                }
                await this.user_DBContext.SaveChangesAsync();
                Response = "pass";
            }
            catch(Exception ex)
            {
                Response = ex.Message;
            }
            
            return Response;
        }

        public async Task<string> RemoveUser(int id)
        {
            var _data = await this.user_DBContext.User.FirstOrDefaultAsync(item => item.Id == id);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.user_DBContext.User.Remove(_data);
                    await this.user_DBContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch(Exception ex)
                {

                }
                

            }
            return Response;
        }
    }
}