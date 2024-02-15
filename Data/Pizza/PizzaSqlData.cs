using System;
using System.Collections.Generic;
using System.Data;
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
        public List<Pizza> GetAll()
        {
            var pizzas = new List<Pizza>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Consulta para obtener las pizzas
                    var pizzaSql = "SELECT IdPizza, NamePizza, Price FROM Pizzas";
                    var pizzaCommand = new SqlCommand(pizzaSql, connection);

                    using (var pizzaReader = pizzaCommand.ExecuteReader())
                    {
                        while (pizzaReader.Read())
                        {
                            var pizza = new Pizza
                            {
                                Id = Convert.ToInt32(pizzaReader["IdPizza"]),
                                Name = pizzaReader["NamePizza"].ToString(),
                                Price = (decimal)pizzaReader["Price"],
                                Ingredients = new List<Ingredientes>()
                            };

                            pizzas.Add(pizza);
                        }
                    }

                    // Consulta para obtener los ingredientes
                    var ingredientsSql = "SELECT PizzaId, IdIngredient, NameIngredient,  Price,  IsGlutenFree " +
                                         "FROM Ingredientes " +
                                         "ORDER BY PizzaId, IdIngredient";

                    var ingredientsCommand = new SqlCommand(ingredientsSql, connection);

                    using (var ingredientsReader = ingredientsCommand.ExecuteReader())
                    {
                        while (ingredientsReader.Read())
                        {
                            var pizzaId = Convert.ToInt32(ingredientsReader["PizzaId"]);
                            var pizza = pizzas.FirstOrDefault(p => p.Id == pizzaId);

                            if (pizza != null)
                            {
                                var ingredient = new Ingredientes
                                {
                                    IdIngredient = Convert.ToInt32(ingredientsReader["IdIngredient"]),
                                    NameIngredient = ingredientsReader["NameIngredient"].ToString(),
                                    PizzaId = (int)ingredientsReader["PizzaId"],
                                    Price = (decimal)ingredientsReader["Price"],
                                    IsGlutenFree = Convert.ToBoolean(ingredientsReader["IsGlutenFree"])
                                };

                                pizza.Ingredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw new Exception("Error al obtener las pizzas e ingredientes: " + ex.Message, ex);
            }

            return pizzas;
        }



        public Pizza Get(int Id)
        {
            var pizza = new Pizza();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sqlString = "SELECT IdPizza, NamePizza, Price FROM Pizzas WHERE IdPizza = @Id";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@Id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pizza = new Pizza
                            {
                                Id = Convert.ToInt32(reader["IdPizza"]),
                                Name = reader["NamePizza"].ToString(),
                                Price = (decimal)reader["Price"],
                                Ingredients = new List<Ingredientes>() 
                            };
                            reader.Close();
                        }
                    }

                    // Ahora, consulta los ingredientes para esta pizza
                    var ingredientsSql = "SELECT IdIngredient, PizzaId, NameIngredient, Price,  IsGlutenFree " +
                                         "FROM Ingredientes " +
                                         "WHERE PizzaId = @PizzaId";
                    var ingredientsCommand = new SqlCommand(ingredientsSql, connection);
                    ingredientsCommand.Parameters.AddWithValue("@PizzaId", pizza.Id);

                    using (var ingredientsReader = ingredientsCommand.ExecuteReader())
                    {
                        while (ingredientsReader.Read())
                        {
                            var ingredient = new Ingredientes
                            {
                                IdIngredient = Convert.ToInt32(ingredientsReader["IdIngredient"]),
                                NameIngredient = ingredientsReader["NameIngredient"].ToString(),
                                PizzaId = (int)ingredientsReader["PizzaId"],
                                Price = (decimal)ingredientsReader["Price"],
                                IsGlutenFree = Convert.ToBoolean(ingredientsReader["IsGlutenFree"])
                            };

                            // Agrega el ingrediente a la lista de ingredientes de la pizza
                            pizza.Ingredients.Add(ingredient);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw;
            }
            return pizza;
        }
        public void Add(Pizza pizza)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        // Generar un ID único para la pizza
                        var maxIdSql = "SELECT MAX(IdPizza) FROM Pizzas";
                        var maxIdCommand = new SqlCommand(maxIdSql, connection, transaction);
                        var maxIdResult = maxIdCommand.ExecuteScalar();
                        var pizzaId = (maxIdResult != DBNull.Value) ? Convert.ToInt32(maxIdResult) + 1 : 1;

                        // Inserta la pizza en la tabla "Pizzas"
                        var insertPizzaSql = "INSERT INTO Pizzas (IdPizza, NamePizza, Price) VALUES (@IdPizza, @NamePizza, @Price)";
                        var insertPizzaCommand = new SqlCommand(insertPizzaSql, connection, transaction);
                        insertPizzaCommand.Parameters.AddWithValue("@IdPizza", pizzaId);
                        insertPizzaCommand.Parameters.AddWithValue("@NamePizza", pizza.Name);
                        insertPizzaCommand.Parameters.AddWithValue("@Price", pizza.Price);
                        insertPizzaCommand.ExecuteNonQuery();

                        // Inserta los ingredientes en la tabla "Ingredientes"
                        foreach (var ingredient in pizza.Ingredients)
                        {
                            var insertIngredientSql = "INSERT INTO Ingredientes (PizzaId,IdIngredient, NameIngredient,  Price,  IsGlutenFree) " +
                                                      "VALUES (@PizzaId,@IdIngredient, @NameIngredient,  @Price,@IsGlutenFree)";
                            var insertIngredientCommand = new SqlCommand(insertIngredientSql, connection, transaction);
                            insertIngredientCommand.Parameters.AddWithValue("@PizzaId", pizzaId);
                            insertIngredientCommand.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                            insertIngredientCommand.Parameters.AddWithValue("@IdIngredient", ingredient.IdIngredient);
                            insertIngredientCommand.Parameters.AddWithValue("@Price", ingredient.Price);
                            insertIngredientCommand.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);

                            insertIngredientCommand.ExecuteNonQuery();
                        }

                        // Confirma la transacción
                        transaction.Commit();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Maneja la excepción de SQL Server aquí
                throw new Exception("Error de SQL Server: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones aquí
                throw new Exception("Error general: " + ex.Message, ex);
            }
        }



        public void Delete(int Id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sqlString = "DELETE FROM Pizzas WHERE idPizza = @idPizza";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@idPizza", Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Manejar o registrar la excepción SQL específica
                throw;
            }
            catch (Exception ex)
            {
                // Manejar o registrar excepciones generales
                throw;
            }
        }
        public void Update(Pizza pizza)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Actualiza los datos de la pizza en la tabla Pizzas
                    var updatePizzaSql = "UPDATE Pizzas SET NamePizza = @NamePizza, Price = @Price WHERE IdPizza = @IdPizza";
                    var updatePizzaCommand = new SqlCommand(updatePizzaSql, connection);
                    updatePizzaCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                    updatePizzaCommand.Parameters.AddWithValue("@NamePizza", pizza.Name);
                    updatePizzaCommand.Parameters.AddWithValue("@Price", pizza.Price);
                    updatePizzaCommand.ExecuteNonQuery();

                    // Borra todos los ingredientes de la pizza de la tabla Ingredientes
                    var deleteIngredientsSql = "DELETE FROM Ingredientes WHERE PizzaId = @IdPizza";
                    var deleteIngredientsCommand = new SqlCommand(deleteIngredientsSql, connection);
                    deleteIngredientsCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                    deleteIngredientsCommand.ExecuteNonQuery();

                    // Inserta los nuevos ingredientes en la tabla Ingredientes
                    foreach (var ingredient in pizza.Ingredients)
                    {
                        var insertIngredientSql = "INSERT INTO Ingredientes (PizzaId, NameIngredient, Price, IsGlutenFree) " +
                                                  "VALUES (@IdPizza, @NameIngredient, @Price, @IsGlutenFree)";
                        var insertIngredientCommand = new SqlCommand(insertIngredientSql, connection);
                        insertIngredientCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                        insertIngredientCommand.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                        insertIngredientCommand.Parameters.AddWithValue("@Price", ingredient.Price);
                        insertIngredientCommand.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);
                        insertIngredientCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw;
            }
        }

    }
}
