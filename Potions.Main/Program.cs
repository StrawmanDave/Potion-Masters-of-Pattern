using System.Threading.Tasks.Dataflow;

PotionType PlayersPotion = PotionType.Water;

while(true)
{
    Console.WriteLine($"Your Current Potion is {PlayersPotion}");
    Console.WriteLine("Do you want to add more ingredients to your potion?");
    string? Input = Console.ReadLine();
    if(Input == "no")
    {
        break;
    }
    Console.WriteLine("Available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");

    Ingredients ingredient = Console.ReadLine() switch 
    {
        "stardust" => Ingredients.Stardust, 
        "snake venom" => Ingredients.SnakeVenom, 
        "dragon breath" => Ingredients.DragonBreath, 
        "shadow glass" => Ingredients.ShadowGlass,
        "eyeshine gem" => Ingredients.EyeshineGem

    };

    PlayersPotion = (ingredient, PlayersPotion) switch
    {
        (Ingredients.Stardust, PotionType.Water) => PotionType.Elixir, //Water plus stardust makes elixir
        (Ingredients.SnakeVenom, PotionType.Elixir) => PotionType.Posion,// Elixir plus snake venom makes poison
        (Ingredients.DragonBreath, PotionType.Elixir) => PotionType.Flying, // Elixir plus dragon breath makes flying potion
        (Ingredients.ShadowGlass, PotionType.Elixir) => PotionType.Invisibility, // Elixir plus shadow glass makes invisibility potion
        (Ingredients.EyeshineGem, PotionType.Elixir) => PotionType.NightSight, // Elixir plus eyesight gem makes night sight potion
        (Ingredients.ShadowGlass, PotionType.NightSight) => PotionType.CloudyBrew, // shadow glass plus night sight potion makes cloudy brew
        (Ingredients.EyeshineGem, PotionType.Invisibility) => PotionType.CloudyBrew, // eyeshine gem plus invisibiligy makes cloudy brew
        (Ingredients.Stardust, PotionType.CloudyBrew) => PotionType.Wraith, // stardust plus cloudy brew makes wraith potion
        (_, _) => PotionType.Ruined, // Anything else results in a ruined potion
    };

    if(PlayersPotion == PotionType.Ruined)
    {
        Console.WriteLine("You ruined the potion lets start over");
        PlayersPotion = PotionType.Water;
    }
}


public enum Ingredients {Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem};
public enum PotionType{ Water, Elixir, Posion, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined};