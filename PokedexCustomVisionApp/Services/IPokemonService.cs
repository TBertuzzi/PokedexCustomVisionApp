using System;
using System.Threading.Tasks;
using PokedexCustomVisionApp.Models;

namespace PokedexCustomVisionApp.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemon(string pokemon);
    }
}
