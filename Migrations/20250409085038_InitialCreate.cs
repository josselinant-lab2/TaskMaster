using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Priorites",
                columns: table => new
                {
                    Id_Priorite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorites", x => x.Id_Priorite);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id_Statut = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id_Statut);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pseudo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Categorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id_Categorie);
                    table.ForeignKey(
                        name: "FK_Categories_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etiquettes",
                columns: table => new
                {
                    Id_Etiquette = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquettes", x => x.Id_Etiquette);
                    table.ForeignKey(
                        name: "FK_Etiquettes_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id_Task = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Echeance = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Id_Categorie = table.Column<int>(type: "int", nullable: false),
                    Id_Priorite = table.Column<int>(type: "int", nullable: false),
                    Id_Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id_Task);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_Id_Categorie",
                        column: x => x.Id_Categorie,
                        principalTable: "Categories",
                        principalColumn: "Id_Categorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Priorites_Id_Priorite",
                        column: x => x.Id_Priorite,
                        principalTable: "Priorites",
                        principalColumn: "Id_Priorite",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuts_Id_Statut",
                        column: x => x.Id_Statut,
                        principalTable: "Statuts",
                        principalColumn: "Id_Statut",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assimilations",
                columns: table => new
                {
                    Id_Task = table.Column<int>(type: "int", nullable: false),
                    Id_Etiquette = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assimilations", x => new { x.Id_Task, x.Id_Etiquette });
                    table.ForeignKey(
                        name: "FK_Assimilations_Etiquettes_Id_Etiquette",
                        column: x => x.Id_Etiquette,
                        principalTable: "Etiquettes",
                        principalColumn: "Id_Etiquette",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assimilations_Tasks_Id_Task",
                        column: x => x.Id_Task,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id_Commentaire = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_Task = table.Column<int>(type: "int", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id_Commentaire);
                    table.ForeignKey(
                        name: "FK_Commentaires_Tasks_Id_Task",
                        column: x => x.Id_Task,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RelationUserTasks",
                columns: table => new
                {
                    Id_RelationUserTasks = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_Task = table.Column<int>(type: "int", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationUserTasks", x => x.Id_RelationUserTasks);
                    table.ForeignKey(
                        name: "FK_RelationUserTasks_Tasks_Id_Task",
                        column: x => x.Id_Task,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationUserTasks_Users_Id_User",
                        column: x => x.Id_User,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    Id_SubTasks = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Statut = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Echeance = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Id_Task = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.Id_SubTasks);
                    table.ForeignKey(
                        name: "FK_SubTasks_Tasks_Id_Task",
                        column: x => x.Id_Task,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Assimilations_Id_Etiquette",
                table: "Assimilations",
                column: "Id_Etiquette");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id_User",
                table: "Categories",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_Id_Task",
                table: "Commentaires",
                column: "Id_Task");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_Id_User",
                table: "Commentaires",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquettes_Id_User",
                table: "Etiquettes",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_RelationUserTasks_Id_Task",
                table: "RelationUserTasks",
                column: "Id_Task");

            migrationBuilder.CreateIndex(
                name: "IX_RelationUserTasks_Id_User",
                table: "RelationUserTasks",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_SubTasks_Id_Task",
                table: "SubTasks",
                column: "Id_Task");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Id_Categorie",
                table: "Tasks",
                column: "Id_Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Id_Priorite",
                table: "Tasks",
                column: "Id_Priorite");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Id_Statut",
                table: "Tasks",
                column: "Id_Statut");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assimilations");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "RelationUserTasks");

            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.DropTable(
                name: "Etiquettes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Priorites");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
