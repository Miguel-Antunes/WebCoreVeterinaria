using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeProp = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpfProp = table.Column<int>(type: "Int", nullable: false),
                    nascimentoProp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nomeAnimal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    especieAnimal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    racaAnimal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    pesoAnimal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fabricanteVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fabricacaoVacina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    validadeVacina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpfVeterinario = table.Column<int>(type: "int", nullable: false),
                    nascimentoVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefoneVeterinario = table.Column<int>(type: "int", nullable: false),
                    enderecoVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cidadeVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ufVeterinario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idAnimal = table.Column<int>(type: "int", nullable: false),
                    nomeVeterinarioid = table.Column<int>(type: "int", nullable: true),
                    idVeterinario = table.Column<int>(type: "int", nullable: false),
                    descricaoVacinaid = table.Column<int>(type: "int", nullable: true),
                    idVacina = table.Column<int>(type: "int", nullable: false),
                    dataProcedimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusDor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusFebre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    queixa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procedimento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Animal_idAnimal",
                        column: x => x.idAnimal,
                        principalTable: "Animal",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Procedimentos_Vacinas_descricaoVacinaid",
                        column: x => x.descricaoVacinaid,
                        principalTable: "Vacinas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Veterinarios_nomeVeterinarioid",
                        column: x => x.nomeVeterinarioid,
                        principalTable: "Veterinarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_cpfProp",
                table: "Animal",
                column: "cpfProp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_descricaoVacinaid",
                table: "Procedimentos",
                column: "descricaoVacinaid");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_idAnimal",
                table: "Procedimentos",
                column: "idAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_nomeVeterinarioid",
                table: "Procedimentos",
                column: "nomeVeterinarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
