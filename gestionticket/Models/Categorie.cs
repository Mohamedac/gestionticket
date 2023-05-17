namespace gestionticket.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

}