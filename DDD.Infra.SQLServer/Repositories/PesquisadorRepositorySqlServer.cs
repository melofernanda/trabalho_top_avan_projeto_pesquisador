using DDD.Domain.PicContext;
using DDD.Domain.PosGradContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
	public class PesquisadorRepositorySqlServer : IPesquisadorRepository
	{

		private readonly SqlContext _context;

		public PesquisadorRepositorySqlServer(SqlContext context)
		{
			_context = context;
		}

		public void DeletePesquisador(Pesquisador pesquisador)
		{
			try
			{
				_context.Set<Pesquisador>().Remove(pesquisador);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public Pesquisador GetPesquisadorById(int id)
		{
			return _context.Pesquisadores.Find(id);
		}

		public List<Pesquisador> GetPesquisadores()
		{
			//return  _context.Pesquisadores.Include(x => x.Projetos).ToList();
			return _context.Pesquisadores.ToList();

		}

		public void InsertPesquisador(Pesquisador pesquisador)
		{
			try
			{
				_context.Pesquisadores.Add(pesquisador);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				//log exception

			}
		}



		public void UpdatePesquisador(Pesquisador pesquisador)
		{
			try
			{
				_context.Entry(pesquisador).State = EntityState.Modified;
				_context.SaveChanges();

			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
        public void PersistirProjeto(ProjetoPersistence projetoPersistence)
        {
            try
            {
                _context.ProjetosP.Add(projetoPersistence);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }
    }
}