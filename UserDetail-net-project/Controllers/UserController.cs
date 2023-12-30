using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using GE = GlobalEntity;

namespace UserDetail_.net_project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBC userBC;
        public UserController(IUserBC userBC)
        {
            this.userBC = userBC;
        }
        public async Task<IActionResult> Index()
        {
            List<GE::User> users = await this.userBC.GetUsers();
            return View(users);
        }
        public IActionResult Create()
        {
            
            return View(new GE.User());
        }

        public async Task<IActionResult> Edit(string id)
        {
            GE::User users = await this.userBC.GetIndividualUser(Convert.ToInt32(id));
            return View("Create",users);
        }
        public async Task<IActionResult> Save(GE::User user)
        {
            string Response = await this.userBC.Save(user);
            return Json(Response);
        }

        public async Task<IActionResult> Remove(int id)
        {
            string Response = await this.userBC.RemoveUser(Convert.ToInt32(id));
            return Json(Response);
        }
        public async Task<IActionResult> GetAll()
        {
            var Response = await this.userBC.GetUsers();
            return Json(Response);
        }
        public async Task<IActionResult> GetDetail(string id)
        {
            var users = await this.userBC.GetIndividualUser(Convert.ToInt32(id));
            return Json(users);
        }
    }
}
