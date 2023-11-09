using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Domain.PosGradContext
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string ProjetoName { get; set; }
        public string ProjetoDescription { get; set; }


        public double AnosDuracao { get; set; }

        public List<Pesquisador>? Pesquisadores { get; set; }
    }
}
