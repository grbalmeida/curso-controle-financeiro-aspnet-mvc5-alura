using Financas.Entidades;
using System.Collections.Generic;

namespace Financas.Models
{
    public class MovimentacoesPorUsuarioModel
    {
        public int? UsuarioId { get; set; }

        public IList<Movimentacao> Movimentacoes { get; set; }

        public IList<Usuario> Usuarios { get; set; }
    }
}