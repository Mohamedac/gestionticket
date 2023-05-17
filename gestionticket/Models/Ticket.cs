namespace gestionticket.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }

        public int PrioriteId { get; set; }
        public virtual Priorite Priorite { get; set; }

        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

        public int AuteurId { get; set; }
        public virtual Client Auteur { get; set; }

        public int? AssigneeId { get; set; }
        public string Statut { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public virtual MembreSupportTechnique Assignee { get; set; }

        public virtual ICollection<PieceJointe> PiecesJointes { get; set; }
    }
}