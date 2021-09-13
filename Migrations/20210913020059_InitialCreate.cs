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
                name: "Vacina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoVacina = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    fabricanteVacina = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    fabricacaoVacina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validadeVacina = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeVeterinario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    cpfVeterinario = table.Column<int>(type: "int", nullable: false),
                    nascimentoVeterinario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefoneVeterinario = table.Column<int>(type: "int", nullable: false),
                    enderecoVeterinario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    cidadeVeterinario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ufVeterinario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
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
                    dataProcedimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusDor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    statusFebre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    statusEstado = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    queixa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    procedimento = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
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
                        name: "FK_Procedimentos_Vacina_descricaoVacinaid",
                        column: x => x.descricaoVacinaid,
                        principalTable: "Vacina",
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
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
