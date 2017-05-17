using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    public class AboutController : Blog_SolutionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test() {

            return View();
        }
	}
}