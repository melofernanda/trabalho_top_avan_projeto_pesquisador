﻿using DDD.Domain.PosGradContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IProjetoRepository
	{
		public List<Projeto> GetProjetos();
		public Projeto GetProjetoById(int id);
		public void InsertProjeto(Projeto projeto);
		public void UpdateProjeto(Projeto projeto);
		public void DeleteProjeto(Projeto projeto);
	}
}
