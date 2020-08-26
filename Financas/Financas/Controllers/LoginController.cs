using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index", "Movimentacao");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                return View(nameof(Index));
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction(nameof(Index));
        }
    }
}