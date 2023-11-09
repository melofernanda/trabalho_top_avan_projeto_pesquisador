﻿using DDD.Domain.PosGradContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class ProjetoRepositorySqlServer : IProjetoRepository
	{
		private readonly SqlContext _context;

		public ProjetoRepositorySqlServer(SqlContext context)
		{
			_context = context;
		}


		public void DeleteProjeto(Projeto projeto)
		{
			try
			{
				_context.Set<Projeto>().Remove(projeto);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public List<Projeto> GetProjetos()
		{
			return _context.Projetos.ToList();
		}

		public Projeto GetProjetoById(int id)
		{
			return _context.Projetos.Find(id);
		}

		public void InsertProjeto(Projeto projeto)
		{
			try
			{
				_context.Projetos.Add(projeto);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				//log exception

			}
		}

		public void UpdateProjeto(Projeto projeto)
		{
			try
			{
				_context.Entry(projeto).State = EntityState.Modified;
				_context.SaveChanges();

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
