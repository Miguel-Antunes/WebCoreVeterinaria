using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeProp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpfProp = table.Column<int>(type: "int", nullable: false),
                    nascimentoProp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomeAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especieAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    racaAnimal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pesoAnimal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.id);
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
                    nomeAnimalid = table.Column<int>(type: "int", nullable: true),
                    nomeVeterinarioid = table.Column<int>(type: "int", nullable: true),
                    descricaoVacinaid = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Procedimentos_Animais_nomeAnimalid",
                        column: x => x.nomeAnimalid,
                        principalTable: "Animais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Procedimentos_descricaoVacinaid",
                table: "Procedimentos",
                column: "descricaoVacinaid");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_nomeAnimalid",
                table: "Procedimentos",
                column: "nomeAnimalid");

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
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
