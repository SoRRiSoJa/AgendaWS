using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaWS.Persistence.Repositories
{
    using AgendaWS.Domain.Models;
    using AgendaWS.Domain.Repositories;
    public class AgendaRepository : IAgendaRepository
    {
        public Task<Agenda> Editar(Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Excluir(int idAgenda)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agenda>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> Obter(int idAgenda)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> ObterPorNumero(string numero)
        {
            throw new NotImplementedException();
        }

        public Task<Agenda> Salvar(Agenda agenda)
        {
            throw new NotImplementedException();
        }
    }
}
