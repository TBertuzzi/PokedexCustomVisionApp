using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PokedexCustomVisionApp.Models;
using HttpExtension;
using System.Diagnostics;
using PokedexCustomVisionApp.Helpers;

namespace PokedexCustomVisionApp.Services
{
    public class PokemonService : IPokemonService     {         public async Task<Pokemon> GetPokemon(string pokemon)         {
            try
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await httpClient.
                    GetAsync<Pokemon>($"{Constantes.PokeApi}{pokemon}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.Value.Image = GetImageStreamFromUrl(response.Value.Sprites.FrontDefault.AbsoluteUri);
                    response.Value.Description = PokedexHelper.RetornaDescricao(response.Value.Name.ToLower());
                    return response.Value;
                }
                else
                {
                    Debug.WriteLine(response.Error.Message);
                    return null;
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }         }          private byte[] GetImageStreamFromUrl(string url)
        {
            try
            {
                using (var webClient = new HttpClient())
                {
                    var imageBytes = webClient.GetByteArrayAsync(url).Result;

                    return imageBytes;

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;

            }
        }     } 
}
