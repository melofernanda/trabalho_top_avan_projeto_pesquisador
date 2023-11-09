using DDD.Domain.PicContext;
using DDD.Domain.PosGradContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Service
{
    public class ValidarProjetoService
    {
        public bool ValidarProjeto(Projeto projeto, Pesquisador pesquisador)
        {
            if (projeto.AnosDuracao > 1 && pesquisador.Titulacao == "Mestre")
            {
                return true; // Projeto válido
            }

            return false; // Projeto inválido
        }
    }
}
