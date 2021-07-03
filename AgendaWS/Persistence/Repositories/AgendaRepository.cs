using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaWS.Persistence.Repositories
{
    using AgendaWS.Domain.Models;
    using AgendaWS.Domain.Repositories;
    using AgendaWS.Middlewares;
    using AgendaWS.Persistence.Config;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgentaContext _context;
        public AgendaRepository(AgentaContext _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public async Task<Agenda> Editar(Agenda agenda)
        {
            var agendaDb = await _context.Agenda.FirstOrDefaultAsync((ag) => ag.Id == agenda.Id);
            if (agendaDb==null)
            {
                throw new HttpResponseException(404, "Registro não encontrado.");
            }
            
            agendaDb.Nome = agenda.Nome;
            agendaDb.Numero = agenda.Numero;
            _context.SaveChanges();
            
            return agendaDb;   
            
        }

        public Task<bool> Excluir(int idAgenda)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Agenda>> Listar()
        {
            return await _context.Agenda.AsNoTracking().ToListAsync();
            
        }

        public async Task<Agenda> Obter(int idAgenda)
        {
            return await _context.Agenda.Where((agenda) => agenda.IsAtivo && agenda.Id == idAgenda).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Agenda>> ObterPorNome(string nome)
        {
            return await _context.Agenda.Where((agenda) => agenda.IsAtivo && agenda.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IEnumerable<Agenda>> ObterPorNumero(string numero)
        {
            return await _context.Agenda.Where((agenda) => agenda.IsAtivo && agenda.Numero.Contains(numero)).ToListAsync();
        }

        public async Task<Agenda> Salvar(Agenda agenda)
        {
              await _context.AddAsync(agenda);
              _context.SaveChanges();
            return agenda;
        }
    }
}
