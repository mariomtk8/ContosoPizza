using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public interface IPizzaData
    {
       List<Pizza> GetAll();
       Pizza Get(int id);
        void Add(Pizza Pizza);
        void Delete(int id);
        void Update(Pizza Pizza);
    }
}