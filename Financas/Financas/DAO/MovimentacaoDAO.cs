using Financas.Entidades;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContext context;

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
    }
}