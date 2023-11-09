using DDD.Application.Service;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.Service;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PesquisadorController : ControllerBase
	{
        private readonly IPesquisadorRepository _pesquisadorRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly ProjetoService _projetoService;
        private ProjetoService? projetoService;

        public PesquisadorController(IPesquisadorRepository pesquisadorRepository)
		{
            _pesquisadorRepository = pesquisadorRepository;
            _projetoService = projetoService;



        }

		// GET: api/<PesquisadoresController>
		[HttpGet]
		public ActionResult<List<Pesquisador>> Get()
		{
			return Ok(_pesquisadorRepository.GetPesquisadores());
		}

		[HttpGet("{id}")]
		public ActionResult<Pesquisador> GetById(int id)
		{
			return Ok(_pesquisadorRepository.GetPesquisadorById(id));
		}


		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Pesquisador> CreatePesquisador(Pesquisador pesquisador)
		{
			
            _pesquisadorRepository.InsertPesquisador(pesquisador);
            return CreatedAtAction(nameof(GetById), new { id = pesquisador.UserId }, pesquisador);
                
			
		}

		[HttpPut]
		public ActionResult Put([FromBody] Pesquisador pesquisador)
		{
			try
			{
				if (pesquisador == null)
					return NotFound();

				_pesquisadorRepository.UpdatePesquisador(pesquisador);
				return Ok("Cliente Atualizado com sucesso!");
			}
			catch (Exception)
			{

				throw;
			}
		}

		// DELETE api/values/5
		[HttpDelete()]
		public ActionResult Delete([FromBody] Pesquisador pesquisador)
		{
			try
			{
				if (pesquisador == null)
					return NotFound();

				_pesquisadorRepository.DeletePesquisador(pesquisador);
				return Ok("Cliente Removido com sucesso!");
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
        [HttpPost]
        [Route("gerarProjeto")]
        public ActionResult GerarProjeto(int idProjeto, int idPesquisador)
        {
            if (_projetoService.GerarProjeto(idProjeto, idPesquisador, _pesquisadorRepository, _projetoRepository))
            {
                return Ok("Projeto gerado com sucesso!");
            }
            else
            {
                return BadRequest("Falha ao gerar o projeto.");
            }
        }



    }
}
