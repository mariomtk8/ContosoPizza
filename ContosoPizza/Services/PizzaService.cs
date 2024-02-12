using ContosoPizza.Models;
using ContosoPizza.Data;
using TetePizza.Services;

namespace ContosoPizza.Services
{
    public class PizzaService : IPizzaServices
    {
        private readonly IPizzaData _pizzaData; 

        public PizzaService(IPizzaData pizzaData)
        {
            _pizzaData = pizzaData;
        }

        public List<Pizza> GetAll() => _pizzaData.GetAll();

        public Pizza? Get(int id) => _pizzaData.Get(id);

        public void Add(Pizza pizza) => _pizzaData.Add(pizza);

        public void Delete(int id) => _pizzaData.Delete(id);

        public void Update(Pizza pizza) => _pizzaData.Update(pizza);
    }
}
