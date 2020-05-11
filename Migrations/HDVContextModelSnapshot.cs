﻿// <auto-generated />
using System;
using HDV_Online.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HDV_Online.Migrations
{
    [DbContext(typeof(HDVContext))]
    partial class HDVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HDV_Online.Models.CategorieProduit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionCategorieProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomCategorieProduit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategorieProduits");
                });

            modelBuilder.Entity("HDV_Online.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreationCompte")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("date");

                    b.Property<string>("EmailClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbCommandesPassees")
                        .HasColumnType("int");

                    b.Property<string>("NomClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroPortable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UtilisateurId")
                        .IsUnique()
                        .HasFilter("[UtilisateurId] IS NOT NULL");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("HDV_Online.Models.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("HDV_Online.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeContactId")
                        .HasColumnType("int");

                    b.Property<int?>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeContactId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HDV_Online.Models.Coordonnee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Code_Postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Facturation")
                        .HasColumnType("bit");

                    b.Property<bool>("Livraison")
                        .HasColumnType("bit");

                    b.Property<int?>("PaysId")
                        .HasColumnType("int");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PaysId");

                    b.ToTable("Coordonnee");
                });

            modelBuilder.Entity("HDV_Online.Models.ListeClientCommercial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommercialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommercialId")
                        .IsUnique()
                        .HasFilter("[CommercialId] IS NOT NULL");

                    b.ToTable("ListeClientCommercials");
                });

            modelBuilder.Entity("HDV_Online.Models.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomPays")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("HDV_Online.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategorieProduit")
                        .HasColumnType("int");

                    b.Property<string>("NomProduit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("QuantiteProd")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategorieProduit");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("HDV_Online.Models.ProduitsCommande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommandeId")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommandeId")
                        .IsUnique()
                        .HasFilter("[CommandeId] IS NOT NULL");

                    b.HasIndex("IdProduit");

                    b.ToTable("ProduitsCommandes");
                });

            modelBuilder.Entity("HDV_Online.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HDV_Online.Models.TypeContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitreTypeContact")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeContacts");
                });

            modelBuilder.Entity("HDV_Online.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("HDV_Online.Models.Client", b =>
                {
                    b.HasOne("HDV_Online.Models.ListeClientCommercial", "Commercial")
                        .WithMany("Client")
                        .HasForeignKey("ClientId");

                    b.HasOne("HDV_Online.Models.Utilisateur", "Utilisateur")
                        .WithOne("Client")
                        .HasForeignKey("HDV_Online.Models.Client", "UtilisateurId");
                });

            modelBuilder.Entity("HDV_Online.Models.Commande", b =>
                {
                    b.HasOne("HDV_Online.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("HDV_Online.Models.Contact", b =>
                {
                    b.HasOne("HDV_Online.Models.TypeContact", "TypeContact")
                        .WithMany("Contact")
                        .HasForeignKey("TypeContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HDV_Online.Models.Utilisateur", "Utilisateur")
                        .WithMany("Contact")
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("HDV_Online.Models.Coordonnee", b =>
                {
                    b.HasOne("HDV_Online.Models.Client", "Client")
                        .WithMany("Coordonnees")
                        .HasForeignKey("ClientId");

                    b.HasOne("HDV_Online.Models.Pays", "Pays")
                        .WithMany("Coordonnee")
                        .HasForeignKey("PaysId");
                });

            modelBuilder.Entity("HDV_Online.Models.ListeClientCommercial", b =>
                {
                    b.HasOne("HDV_Online.Models.Utilisateur", "Commercial")
                        .WithOne("ListeClientCommercial")
                        .HasForeignKey("HDV_Online.Models.ListeClientCommercial", "CommercialId");
                });

            modelBuilder.Entity("HDV_Online.Models.Produit", b =>
                {
                    b.HasOne("HDV_Online.Models.CategorieProduit", "CategorieProduit")
                        .WithMany("Produit")
                        .HasForeignKey("IdCategorieProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HDV_Online.Models.ProduitsCommande", b =>
                {
                    b.HasOne("HDV_Online.Models.Commande", "IdCommande")
                        .WithOne("ProduitsCommandes")
                        .HasForeignKey("HDV_Online.Models.ProduitsCommande", "CommandeId");

                    b.HasOne("HDV_Online.Models.Produit", "Produit")
                        .WithMany("ProduitsCommandes")
                        .HasForeignKey("IdProduit");
                });

            modelBuilder.Entity("HDV_Online.Models.Utilisateur", b =>
                {
                    b.HasOne("HDV_Online.Models.Role", "Role")
                        .WithMany("Utilisateur")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
