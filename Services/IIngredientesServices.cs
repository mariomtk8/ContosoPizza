using ContosoPizza.Models;
using ContosoPizza.Data;
using System.Collections.Generic;

namespace ContosoPizza.Services
{
    public class IngredientesService : IIngredientesData
    {
        private readonly IIngredientesData _ingredientesData;

        public IngredientesService(IIngredientesData ingredientesData)
        {
            _ingredientesData = ingredientesData;
        }

        public Ingredientes? Get(int id) => _ingredientesData.Get(id);
        public List<Ingredientes> GetAll() => _ingredientesData.GetAll();
        public void Add(Ingredientes ingredientes) => _ingredientesData.Add(ingredientes);
        public void Delete(int id) => _ingredientesData.Delete(id);
        public void Update(Ingredientes ingredientes) => _ingredientesData.Update(ingredientes);
    }
}
