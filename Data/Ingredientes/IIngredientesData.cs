using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;
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
