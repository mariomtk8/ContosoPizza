using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    public class IngredientesEfrData : IIngredientesData
    {
        private readonly ContosoPizzaAppContext _context;

        public IngredientesEfrData(ContosoPizzaAppContext context)
        {
            _context = context;
        }

        public List<Ingredientes> GetAll()
        {
            return _context.Ingredientes.ToList();
        }

        public Ingredientes Get(int Id)
        {
            return _context.Ingredientes.FirstOrDefault(ingredientes => ingredientes.IdIngredient == Id);
        }


        public void Add(Ingredientes ingredientes)
        {
            _context.Ingredientes.Add(ingredientes);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var ingredientes = _context.Ingredientes.FirstOrDefault(ingredientes => ingredientes.IdIngredient == id);
            if (ingredientes != null)
            {
                _context.Ingredientes.Remove(ingredientes);
            }
            SaveChanges();
        }

        public void Update(Ingredientes ingredientes)
        {
            _context.Ingredientes.Update(ingredientes);
            SaveChanges();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}