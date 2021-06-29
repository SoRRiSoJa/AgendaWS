using AgendaWS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaWS.Domain.Repositories
{
    public interface IAgendaRepository
    {
        Task<Agenda> Salvar(Agenda agenda);
        Task<Agenda> Editar(Agenda agenda);
        Task<bool> Excluir(int idAgenda);
        Task<IEnumerable<Agenda>> Listar();
        Task<Agenda> Obter(int idAgenda);
        Task<IEnumerable<Agenda>> ObterPorNome(string  nome);
        Task<IEnumerable<Agenda>> ObterPorNumero(string numero);
    }
}
