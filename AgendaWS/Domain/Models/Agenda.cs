namespace AgendaWS.Domain.Models
{
    public class Agenda
    {
        public Agenda()
        {
            IsAtivo = true;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public int Ref { get; set; }
        public bool IsAtivo { get; set; }
    }
}
