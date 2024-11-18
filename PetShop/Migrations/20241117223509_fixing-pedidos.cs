using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Migrations
{
    /// <inheritdoc />
    public partial class fixingpedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Animais_AnimaisId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empregados_EmpregadosId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Servicos_ServicosId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_AnimaisId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EmpregadosId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ServicosId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "AnimaisId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EmpregadosId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ServicosId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AnimalId",
                table: "Pedidos",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EmpregadoId",
                table: "Pedidos",
                column: "EmpregadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Animais_AnimalId",
                table: "Pedidos",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empregados_EmpregadoId",
                table: "Pedidos",
                column: "EmpregadoId",
                principalTable: "Empregados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Servicos_ServicoId",
                table: "Pedidos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Animais_AnimalId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empregados_EmpregadoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Servicos_ServicoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_AnimalId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EmpregadoId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "AnimaisId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpregadosId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicosId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_AnimaisId",
                table: "Pedidos",
                column: "AnimaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EmpregadosId",
                table: "Pedidos",
                column: "EmpregadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ServicosId",
                table: "Pedidos",
                column: "ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Animais_AnimaisId",
                table: "Pedidos",
                column: "AnimaisId",
                principalTable: "Animais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empregados_EmpregadosId",
                table: "Pedidos",
                column: "EmpregadosId",
                principalTable: "Empregados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Servicos_ServicosId",
                table: "Pedidos",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
