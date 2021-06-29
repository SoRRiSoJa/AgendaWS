using AgendaWS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaWS.Persistence.Config
{
    public class AgentaContext:DbContext
    {
        public DbSet<Agenda> Agenda { get; set; }
        
        public AgentaContext(DbContextOptions options) : base(options)
        {

        }
    }
}
