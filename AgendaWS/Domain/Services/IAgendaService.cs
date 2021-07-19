using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaWS.Domain.Services
{
    using AgendaWS.Domain.Models;
    public interface IAgendaService
    {
        Task<Agenda> Salvar(Agenda agenda);
        Task<Agenda> Editar(Agenda agenda);
        Task<bool> Excluir(decimal idAgenda);
        Task<IEnumerable<Agenda>> ObterPorNome(string nome);
        Task<IEnumerable<Agenda>> ObterPorNumero(string numero);
        Task<IEnumerable<Agenda>> Listar();
    }
}
