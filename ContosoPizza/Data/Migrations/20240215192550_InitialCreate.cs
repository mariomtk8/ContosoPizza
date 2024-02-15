using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoPizza.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngredient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameIngredient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsGlutenFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngredient);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPizza",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPizza", x => new { x.PedidoId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_PedidoPizza_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoPizza_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "IdPedido", "Price" },
                values: new object[,]
                {
                    { 1, 100.00m },
                    { 2, 150.00m }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Margherita", 8.50m },
                    { 2, "Hawaiana", 9.99m },
                    { 3, "Cuatro Estaciones", 10.75m },
                    { 4, "Barbacoa", 11.25m },
                    { 5, "Vegana", 12.00m }
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngredient", "IsGlutenFree", "NameIngredient", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 1, true, "Salsa de Tomate", 1, 0.5m },
                    { 2, true, "Queso Mozzarella", 1, 1.0m },
                    { 3, true, "Albahaca", 1, 0.3m },
                    { 4, false, "Jamón", 2, 1.2m },
                    { 5, true, "Piña", 2, 0.8m },
                    { 6, true, "Hongos", 3, 0.6m },
                    { 7, true, "Alcachofas", 3, 0.7m },
                    { 8, true, "Aceitunas", 3, 0.5m },
                    { 9, false, "Carne de Res", 4, 1.5m },
                    { 10, true, "Salsa Barbacoa", 4, 0.9m },
                    { 11, true, "Queso Vegano", 5, 2.0m },
                    { 12, true, "Pimiento", 5, 0.4m },
                    { 13, true, "Cebolla Morada", 5, 0.3m },
                    { 14, true, "Calabacín", 5, 0.45m }
                });

            migrationBuilder.InsertData(
                table: "PedidoPizza",
                columns: new[] { "PedidoId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PizzaId",
                table: "Ingredientes",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPizza_PizzaId",
                table: "PedidoPizza",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "PedidoPizza");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
