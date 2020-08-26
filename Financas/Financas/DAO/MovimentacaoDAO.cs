using Financas.Entidades;
using Financas.Models;
using System.Collections.Generic;
using System.Linq;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private readonly FinancasContext context;

        public MovimentacaoDAO(FinancasContext context)
        {
            this.context = context;
        }

        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscarPorUsuario(int? usuarioId)
        {
            return context.Movimentacoes.Where(m => m.UsuarioId == usuarioId).ToList();
        }

        public IList<Movimentacao> Busca(BuscaMovimentacoesModel model)
        {
            IQueryable<Movimentacao> busca = context.Movimentacoes;

            if (model.ValorMinimo.HasValue)
            {
                busca = busca.Where(m => m.Valor >= model.ValorMinimo);
            }

            if (model.ValorMaximo.HasValue)
            {
                busca = busca.Where(m => m.Valor <= model.ValorMaximo);
            }

            if (model.DataMinima.HasValue)
            {
                busca = busca.Where(m => m.Data >= model.DataMinima);
            }

            if (model.DataMaxima.HasValue)
            {
                busca = busca.Where(m => m.Data <= model.DataMaxima);
            }

            if (model.Tipo.HasValue)
            {
                busca = busca.Where(m => m.Tipo == model.Tipo);
            }

            if (model.UsuarioId.HasValue)
            {
                busca = busca.Where(m => m.UsuarioId == model.UsuarioId);
            }

            return busca.ToList();
        }
    }
}