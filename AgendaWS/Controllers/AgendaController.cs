using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaWS.Controllers
{
    using AgendaWS.Domain.Models;
    using AgendaWS.Domain.Services;

    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;
        public AgendaController(IAgendaService _agendaService)
        {
        
            this._agendaService = _agendaService ?? throw new ArgumentNullException(nameof(_agendaService));
        }
        [HttpPost]
        public async Task<ActionResult<Agenda>> Salvar([FromBody] Agenda agenda)
        {
            return Ok(await _agendaService.Salvar(agenda));
        }
        [HttpPut]
        public async Task<ActionResult<Agenda>> Editar([FromBody] Agenda agenda)
        {
            return Ok(await _agendaService.Salvar(agenda));
        }
        [HttpDelete("{idAgenda}")]
        public async Task<ActionResult<Agenda>> Excluir(int idAgenda)
        {
            return Ok(await _agendaService.Excluir(idAgenda));
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Agenda>>> Listar()
        {
            return Ok(await _agendaService.Listar());
        }
        [HttpGet("numero/{numeroTelefone}")]
        public async Task<ActionResult<IEnumerable<Agenda>>> ConsultarPorNumero(string numeroTelefone)
        {
            return Ok( await _agendaService.ObterPorNumero(numeroTelefone));
        }
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Agenda>>> ConsultarPorNome(string nome)
        {
            return Ok(await _agendaService.ObterPorNome(nome));
        }
    }
}
