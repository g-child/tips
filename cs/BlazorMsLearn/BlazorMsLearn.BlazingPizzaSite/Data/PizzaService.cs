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
                Name = "�s�U",
                Description = "�}���Q���[�^�s�U",
                Vegetarian = false,
                Vegan = false,
                Price = 14
            }
       });
    }
}