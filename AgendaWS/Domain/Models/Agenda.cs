using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWS.Domain.Models
{

    [Table("Contato")]
    public class Agenda
    {
        public Agenda()
        {
            IsAtivo = true;
        }
        [Key]
        [Column("Codigo")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Numero")]
        public string Numero { get; set; }
        [Column("Ref")]
        public int Ref { get; set; }
        [Column("IsAtivo")]
        public bool IsAtivo { get; set; }
    }
}
