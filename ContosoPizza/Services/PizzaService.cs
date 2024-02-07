using ContosoPizza.Models;
using ContosoPizza.Data;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly IPizzaData _pizzaData;

    public PizzaService(IPizzaData pizzaData)
    {
        _pizzaData = pizzaData;
    }

    public List<Pizza> GetAll()
    {
        return _pizzaData.GetAll();
    }

    public Pizza Get(int id)
    {
        return _pizzaData.Get(id);
    }

    public void Add(Pizza pizza)
    {
        _pizzaData.Add(pizza);
    }

    public void Delete(int id)
    {
        _pizzaData.Delete(id);
    }

    public void Update(Pizza pizza)
    {
        _pizzaData.Update(pizza);
    }
}
