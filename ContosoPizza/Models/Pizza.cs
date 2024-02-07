namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price {get; set;}
    public bool IsGlutenFree { get; set; }
    public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

}

