using System;
namespace PokedexCustomVisionApp.Helpers
{
    public class PokedexHelper
    {
       public static string RetornaDescricao(string pokemon)
        {
            switch(pokemon)
            {
                case "pikachu":
                    return "Pikachu, the Mouse Pokémon. It can generate electric attacks from the electric pouches located in both of its cheeks.";
                case "charmander":
                    return "Charmander. A flame burns on the tip of its tail from birth. It is said that a Charmander dies if its flame ever goes out.";
                case "bulbasaur":
                    return "Bulbasaur. It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal.";
                case "squirtle":
                    return "Squirtle. This Tiny Turtle Pokémon draws its long neck into its shell to launch incredible water attacks with amazing range and accuracy.";
                default:
                    return "";
            }
        }
    }
}
