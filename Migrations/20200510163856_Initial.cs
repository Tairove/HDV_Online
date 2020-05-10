using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieProduits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCategorieProduit = table.Column<string>(nullable: true),
                    DescriptionCategorieProduit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitreTypeContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(nullable: true),
                    EmailUtilisateur = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateur_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    NomContact = table.Column<string>(nullable: true),
                    PrenomContact = table.Column<string>(nullable: true),
                    EmailContact = table.Column<string>(nullable: true),
                    TelephoneContact = table.Column<string>(nullable: true),
                    UtilisateurId = table.Column<int>(nullable: true),
                    TypeContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_TypeContacts_TypeContactId",
                        column: x => x.TypeContactId,
                        principalTable: "TypeContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListeClientCommercials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeClientCommercials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListeClientCommercials_Utilisateur_CommercialId",
                        column: x => x.CommercialId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrenomClient = table.Column<string>(nullable: true),
                    NomClient = table.Column<string>(nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "date", nullable: false),
                    EmailClient = table.Column<string>(nullable: true),
                    NumeroPortable = table.Column<string>(nullable: true),
                    DateCreationCompte = table.Column<DateTime>(type: "date", nullable: false),
                    NbCommandesPassees = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    UtilisateurId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_ListeClientCommercials_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ListeClientCommercials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCommande = table.Column<DateTime>(type: "date", nullable: false),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coordonnee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_Postal = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Facturation = table.Column<bool>(nullable: false),
                    Livraison = table.Column<bool>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    PaysId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordonnee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordonnee_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordonnee_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduitsCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitsCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduitsCommandes_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProduit = table.Column<string>(nullable: true),
                    DescriptionProduit = table.Column<string>(nullable: true),
                    Prix = table.Column<float>(nullable: false),
                    QuantiteProd = table.Column<int>(nullable: false),
                    IdProduit = table.Column<int>(nullable: true),
                    CategorieProduitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_CategorieProduits_CategorieProduitId",
                        column: x => x.CategorieProduitId,
                        principalTable: "CategorieProduits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produits_ProduitsCommandes_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "ProduitsCommandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientId",
                table: "Client",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UtilisateurId",
                table: "Client",
                column: "UtilisateurId",
                unique: true,
                filter: "[UtilisateurId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TypeContactId",
                table: "Contacts",
                column: "TypeContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UtilisateurId",
                table: "Contacts",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordonnee_ClientId",
                table: "Coordonnee",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordonnee_PaysId",
                table: "Coordonnee",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_ListeClientCommercials_CommercialId",
                table: "ListeClientCommercials",
                column: "CommercialId",
                unique: true,
                filter: "[CommercialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieProduitId",
                table: "Produits",
                column: "CategorieProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdProduit",
                table: "Produits",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitsCommandes_CommandeId",
                table: "ProduitsCommandes",
                column: "CommandeId",
                unique: true,
                filter: "[CommandeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_RoleId",
                table: "Utilisateur",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Coordonnee");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "TypeContacts");

            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.DropTable(
                name: "CategorieProduits");

            migrationBuilder.DropTable(
                name: "ProduitsCommandes");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ListeClientCommercials");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
