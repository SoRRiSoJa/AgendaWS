using AgendaWS.Domain.Models;
using AgendaWS.Domain.Repositories;
using AgendaWS.Domain.Services;
using AgendaWS.Middlewares;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AgendaWS.Service
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaService(IAgendaRepository _agendaRepository)
        {
            this._agendaRepository = _agendaRepository ?? throw new ArgumentNullException(nameof(_agendaRepository));
        }
        public async Task<Agenda> Editar(Agenda agenda)
        {
            if (agenda == null)
            {
                throw new HttpResponseException(400, "Você deve informar os dados para executar esta operação");
            }
            var agendaAntiga = await _agendaRepository.Obter(agenda.Id);
            if (agendaAntiga == null)
            {
                throw new HttpResponseException(404, "Registro não encontrado para edição.");
            }
            agenda.Id = agendaAntiga.Id;
            return await _agendaRepository.Editar(agenda);
        }

        public async Task<bool> Excluir(int idAgenda)
        {
            var agendaAntiga = await _agendaRepository.Obter(idAgenda);
            if (agendaAntiga == null)
            {
                throw new HttpResponseException(404, "Registro não encontrado para exclusão.");
            }
            return await _agendaRepository.Excluir(idAgenda);
        }

        public async Task<IEnumerable<Agenda>> Listar()
        {
            return await _agendaRepository.Listar();
        }

        public async Task<IEnumerable<Agenda>> ObterPorNome(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new HttpResponseException(400, "Você deve informar um nome para consulta.");
            }
            return await _agendaRepository.ObterPorNome(nome);
        }

        public async Task<IEnumerable<Agenda>> ObterPorNumero(string numero)
        {
            if (String.IsNullOrEmpty(numero))
            {
                throw new HttpResponseException(400, "Você deve informar um numero para consulta.");
            }
            if (numero.Length <= 2)
            {
                throw new HttpResponseException(400, "Você deve informar pelo menos 3 digitos para consulta.");
            }
            return await _agendaRepository.ObterPorNumero(numero);
        }

        public  async Task<Agenda> Salvar(Agenda agenda)
        {
            if (agenda == null)
            {
                throw new HttpResponseException(400, "Você deve informar os dados para executar esta operação");
            }
            return await _agendaRepository.Salvar(agenda);
        }
    }
}
