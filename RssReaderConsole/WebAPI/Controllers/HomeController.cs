using System.Web.Mvc;

using Services;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult AllNews()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadAllNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult HabrNews()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadHabrNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReadInterfaxNews()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadInterfaxNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }
    }
}
