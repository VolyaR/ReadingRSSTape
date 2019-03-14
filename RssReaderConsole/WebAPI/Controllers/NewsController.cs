using System.Web.Mvc;

using Services;

namespace WebAPI.Controllers
{
    public class NewsController : Controller
    {
        public JsonResult All()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadAllNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Habr()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadHabrNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult Interfax()
        {
            var reader = new DataBaseReader();
            var news = reader.ReadInterfaxNews();
            return Json(news, JsonRequestBehavior.AllowGet);
        }
    }
}
