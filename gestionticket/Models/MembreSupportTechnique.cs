namespace gestionticket.Models
{
    public class MembreSupportTechnique
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public virtual ICollection<Ticket> TicketsAssignes { get; set; }
    }
}