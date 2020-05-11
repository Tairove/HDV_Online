using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class HDVContext : DbContext
    {
        public HDVContext(DbContextOptions<HDVContext> options)
    : base(options)
        {
        }
        public DbSet<CategorieProduit> CategorieProduits { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Coordonnee> Coordonnee { get; set; }
        public DbSet<ListeClientCommercial> ListeClientCommercials { get; set; }
        public DbSet<Pays> Pays { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<ProduitsCommande> ProduitsCommandes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TypeContact> TypeContacts { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>()
                .HasOne(r => r.Role)
                .WithMany(r => r.Utilisateur)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<Produit>()
                .HasOne(r => r.CategorieProduit)
                .WithMany(r => r.Produit)
                .HasForeignKey(r => r.IdCategorieProduit);
        }
    }
}
