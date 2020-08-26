using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Financas.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private readonly MovimentacaoDAO movimentacaoDAO;
        private readonly UsuarioDAO usuarioDAO;

        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Movimentacao
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.Adiciona(movimentacao);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.Lista();
                return View(nameof(Form), movimentacao);
            }
        }

        public ActionResult Index()
        {
            IList<Movimentacao> movimentacoes = movimentacaoDAO.Lista();
            return View(movimentacoes);
        }

        public ActionResult MovimentacoesPorUsuario(MovimentacoesPorUsuarioModel model)
        {
            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.BuscarPorUsuario(model.UsuarioId);
            return View(model);
        }

        public ActionResult Busca(BuscaMovimentacoesModel model)
        {
            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.Busca(model);
            return View(model);
        }
    }
}