using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public interface IIngredientesData
    {
      Ingredientes Get(int id);
      List<Ingredientes> GetAll();
      void Add(Ingredientes ingredientes);
      void Delete(int id);
      void Update(Ingredientes ingredientes);
    }
}
