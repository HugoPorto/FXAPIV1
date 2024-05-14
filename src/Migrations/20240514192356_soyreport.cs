using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FXAPIV1.Migrations
{
    /// <inheritdoc />
    public partial class soyreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoyReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Produto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderServiceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroNotaFiscal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PesoLiquido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroLacre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlacaCaminhao1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlacaCaminhao2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlacaCaminhao3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Transportadora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PesoAmostra = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SojaIntacta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CNPJParticipante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VistoriaVeiculo = table.Column<bool>(type: "bit", nullable: false),
                    Umidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Impureza = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ardidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Queimados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FermentadosChocosImaturoGerminado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mofados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Esverdeados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PartidosQuebradosAmassados = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalAvariado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeClassificador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeMotorista = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QrCodePDF = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrdemCarga = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoyReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoyReports");
        }
    }
}
