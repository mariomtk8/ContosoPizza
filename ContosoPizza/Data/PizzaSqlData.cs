using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class PizzaSqlData : IPizzaData
    {
        private readonly string _connectionString;

        public PizzaSqlData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Pizza pizza)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "INSERT INTO Pizzas (idPizza, Nombre, Price) VALUES (@IdPizza, @Nombre, @Price)";
                var command = new SqlCommand(sqlString, connection);

                command.Parameters.AddWithValue("@IdPizza", pizza.Id);
                command.Parameters.AddWithValue("@Nombre", pizza.Name);
                command.Parameters.AddWithValue("@Price", pizza.Price);

                command.ExecuteNonQuery();
            }
        }

        public Pizza Get(int id)
        {
            var pizza = new Pizza();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT idPizza, Nombre, Price FROM Pizzas WHERE idPizza = @idPizza";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@idPizza", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pizza.Id = Convert.ToInt32(reader["idPizza"].ToString());
                        pizza.Name = reader["Nombre"].ToString();
                        pizza.Price = (decimal)reader["Price"];
                    }
                }
            }
            return pizza;
        }

        public List<Pizza> GetAll()
        {
            var pizzas = new List<Pizza>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT idPizza, Nombre, Price FROM Pizzas";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pizza = new Pizza
                        {
                            Id = Convert.ToInt32(reader["idPizza"].ToString()),
                            Name = reader["Nombre"].ToString(),
                            Price = (decimal)reader["Price"]
                        };

                        pizzas.Add(pizza);
                    }
                }
            }
            return pizzas;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlString = "DELETE FROM Pizzas WHERE idPizza = @idPizza";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@idPizza", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Pizza pizza)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlString = "UPDATE Pizzas SET Nombre = @Nombre, Price = @Price WHERE idPizza = @idPizza";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Nombre", pizza.Name);
                command.Parameters.AddWithValue("@Price", pizza.Price);
                command.Parameters.AddWithValue("@idPizza", pizza.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
