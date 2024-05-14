using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FXAPIV1.Migrations
{
    /// <inheritdoc />
    public partial class orderservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalEmbarque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalEmbarqueEndereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DestinoEndereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalCaminhaoEmbarcado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SaldoOS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PesoContratado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Finalizado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderService", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderService");
        }
    }
}
