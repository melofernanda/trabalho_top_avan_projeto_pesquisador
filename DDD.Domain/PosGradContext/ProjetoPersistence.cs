using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.PosGradContext
{
    public class ProjetoPersistence
    {
        public int ProjetoPersistenceId { get; set; }
        public Pesquisador Pesquisador { get; set; }
        public int PesquisadorId { get; set; }
        public int ProjetoId { get; set; }
        public  double AnosDuracao { get; set; }
    }
}
