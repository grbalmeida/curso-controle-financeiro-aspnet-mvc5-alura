using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(
                        model.Nome,
                        model.Senha,
                        new { model.Email }
                    );

                    return RedirectToAction(nameof(Index));
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View(nameof(Form), model);
                }
            }
            else
            {
                return View(nameof(Form), model);
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}