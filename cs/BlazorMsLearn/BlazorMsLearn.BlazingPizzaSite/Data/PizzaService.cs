namespace BlazorMsLearn.BlazingPizzaSite.Data;

public class PizzaService
{
    public async Task<Pizza[]> GetPizzasAsync()
    {
        return await Task.FromResult(new Pizza[]
        {
            new()
            {
                PizzaId = 1,
                Name = "ピザ",
                Description = "マルゲリータピザ",
                Vegetarian = false,
                Vegan = false,
                Price = 14
            }
       });
    }
}