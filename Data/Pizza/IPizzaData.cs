using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public interface IPizzaData
    {
     List<Pizza> GetAll();
     Pizza Get(int Id);
     void Add(Pizza pizza);
     void Delete(int id);
     void Update(Pizza pizza);
    }
}
 