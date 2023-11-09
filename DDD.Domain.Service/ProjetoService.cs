using DDD.Domain.PosGradContext;
using DDD.Infra.SQLServer.Interfaces;

namespace DDD.Domain.Service
{
    public class ProjetoService
    {
        public bool GerarProjeto(int idProjeto, int idPesquisador, IPesquisadorRepository pesquisadorRepository, IProjetoRepository projetoRepository)
        {
            var projeto = projetoRepository.GetProjetoById(idProjeto);
            var pesquisador = pesquisadorRepository.GetPesquisadorById(idPesquisador);

            if (projeto != null && pesquisador != null)
            {
                
                    pesquisadorRepository.PersistirProjeto(new ProjetoPersistence
                    {
                        ProjetoId = projeto.ProjetoId,
                        PesquisadorId = pesquisador.UserId,
                        AnosDuracao = projeto.AnosDuracao
                    });
                    return true;
                
            }

            return false;
        }
    }
}
