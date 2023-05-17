using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestionticket.Models;

namespace gestionticket.Data
{
    public class gestionticketContext : DbContext
    {
        public gestionticketContext (DbContextOptions<gestionticketContext> options)
            : base(options)
        {
        }

        public DbSet<gestionticket.Models.Ticket> Ticket { get; set; } 
        public DbSet<gestionticket.Models.PieceJointe> PieceJointe { get; set; }
        public DbSet<gestionticket.Models.Client> Client { get; set; }
        public DbSet<gestionticket.Models.Categorie> Categorie { get; set; } 
        public DbSet<gestionticket.Models.MembreSupportTechnique> MembreSupportTechnique { get; set; } 
        public DbSet<gestionticket.Models.Priorite> Priorite { get; set; }
 
        public DbSet<gestionticket.Models.Rapport> Rapport { get; set; }
       
        public DbSet<gestionticket.Models.Statistiques> Statistique { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Auteur)
                .HasForeignKey(t => t.AuteurId);

            modelBuilder.Entity<MembreSupportTechnique>()
                .HasMany(mst => mst.TicketsAssignes)
                .WithOne(t => t.Assignee)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Priorite)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PrioriteId);

            modelBuilder.Entity<Ticket>()
    .HasOne(t => t.Categorie)
    .WithMany(c => c.Tickets)
    .HasForeignKey(t => t.CategorieId);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.PiecesJointes)
                .WithOne(pj => pj.Ticket)
                .HasForeignKey(pj => pj.TicketId);
        }


    }
}
