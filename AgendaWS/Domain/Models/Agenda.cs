using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaWS.Domain.Models
{

    [Table("contato")]
    public class Agenda
    {
        public Agenda()
        {
            IsAtivo = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codigo")]
        public decimal Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("numero")]
        public string Numero { get; set; }
        [Column("ref")]
        public decimal Ref { get; set; }
        [Column("isAtivo")]
        public bool IsAtivo { get; set; }
    }
}
