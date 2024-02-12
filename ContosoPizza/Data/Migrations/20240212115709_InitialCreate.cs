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
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdOrder);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidosIdOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Pedidos_PedidosIdOrder",
                        column: x => x.PedidosIdOrder,
                        principalTable: "Pedidos",
                        principalColumn: "IdOrder");
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

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "PedidosIdOrder", "Price" },
                values: new object[,]
                {
                    { 1, "Classic Italian", null, 7.02m },
                    { 2, "Vegetariana", null, 6.77m },
                    { 3, "Pepperoni", null, 9.12m },
                    { 4, "8 Quesos", null, 10.50m }
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngredient", "IsGlutenFree", "NameIngredient", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 1, true, "Tomate", 1, 0.22m },
                    { 2, false, "Prosciutto", 1, 1.3m },
                    { 3, true, "Queso Parmesano", 1, 2.5m },
                    { 4, true, "Aceite de Oliva", 1, 3.0m },
                    { 5, true, "Tomate", 2, 0.22m },
                    { 6, true, "Espinaca", 2, 0.3m },
                    { 7, true, "Champiñones", 2, 0.25m },
                    { 8, true, "Tomate", 3, 0.22m },
                    { 9, false, "Pepperoni", 3, 1.5m },
                    { 10, true, "Oregano", 3, 0.1m },
                    { 11, true, "Tomate", 4, 0.22m },
                    { 12, true, "Queso Mozzarella", 4, 2.0m },
                    { 13, true, "Queso Cheddar", 4, 1.5m },
                    { 14, true, "Queso Gouda", 4, 1.8m },
                    { 15, true, "Queso Brie", 4, 2.2m },
                    { 16, true, "Queso Roquefort", 4, 3.5m },
                    { 17, true, "Queso Gruyere", 4, 2.6m },
                    { 18, true, "Queso Emmental", 4, 2.3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PizzaId",
                table: "Ingredientes",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PedidosIdOrder",
                table: "Pizzas",
                column: "PedidosIdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
