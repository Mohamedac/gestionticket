namespace gestionticket.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }

        // Cette liste de tickets est maintenant optionnelle
        public virtual ICollection<Ticket> Tickets { get; set; }
    }

}
