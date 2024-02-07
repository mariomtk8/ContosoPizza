using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ContosoPizza.Data;
using ContosoPizza.Models;

namespace TetePizza.Data
{
    public class PedidosSqlData : IPedidosData
    {
        private readonly string _connectionString;

        public PedidosSqlData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Pedido Get(int id)
        {
            var pedido = new Pedido();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT IdOrder, Price FROM Pedidos WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedido.Id = Convert.ToInt32(reader["IdPedido"]);
                        pedido.Precio = (decimal)reader["cantidad"];
                    }
                }
            }

            return pedido;
        }

        public void Add(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "INSERT INTO Pedidos (Price) VALUES (@Price); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Price", pedido.Precio);

                int newOrderId = Convert.ToInt32(command.ExecuteScalar());

                pedido.Id = newOrderId;
            }
        }

        public void Update(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "UPDATE Pedidos SET Price = @Price WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", pedido.Id);
                command.Parameters.AddWithValue("@Price", pedido.Precio);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "DELETE FROM Pedidos WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Pedido> GetAll()
        {
            var pedidos = new List<Pedido>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT IdOrder, Price FROM Pedidos";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedido = new Pedido
                        {
                            Id = Convert.ToInt32(reader["IdPedido"]),
                            Precio = (decimal)reader["cantidad"]
                        };

                        pedidos.Add(pedido);
                    }
                }
            }

            return pedidos;
        }
    }
}
