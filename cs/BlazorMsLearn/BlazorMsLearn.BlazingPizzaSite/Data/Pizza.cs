namespace BlazorMsLearn.BlazingPizzaSite.Data;

public class Pizza
{
    public required int PizzaId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required bool Vegetarian { get; set; }
    public required bool Vegan { get; set; }
}
