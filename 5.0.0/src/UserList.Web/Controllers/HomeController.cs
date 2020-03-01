using Microsoft.AspNetCore.Mvc;


namespace UserList.Web.Controllers
{
    public class HomeController : UserListControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult About()
        {
            return View();
        }
       
    }
}