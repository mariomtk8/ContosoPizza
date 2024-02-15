using System.Dynamic;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public interface IPizzaServices
    {
        void Add(Pizza pizza);
        Pizza Get(int id);
        void Delete(int id);
        List<Pizza> GetAll();
        void Update(Pizza pizza);
    }
}
