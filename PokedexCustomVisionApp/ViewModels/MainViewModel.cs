using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using PokedexCustomVisionApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.MVVMBase.Services.Navigation;
using Xamarin.Forms.MVVMBase.ViewModels;

namespace PokedexCustomVisionApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public ICommand VerificarPokemonCommand { get; }
        private ICustomVision _CustomVision;
        private IPokemonService _PokemonService;

        public MainViewModel(ICustomVision customVision,IPokemonService pokemonService) : base("Pokedex")
        {
            VerificarPokemonCommand = new Command(ExecuteVerificarPokemonCommand);

            _CustomVision = customVision;
            _PokemonService = pokemonService;
        }

        private async void ExecuteVerificarPokemonCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {

                await  DialogService.AlertAsync("Erro na Camera", "Camera indisponivel.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Pokemons",
                Name = $"pokemon{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg",
                PhotoSize = PhotoSize.Small
            });

            /*
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000
             */

            if (file == null)
            {
                await DialogService.AlertAsync("Erro na Camera", "Erro ao capturar a imagem.", "OK");
                return;
            }

            string result = string.Empty;
            using (var Dialog = UserDialogs.Instance.Loading("Processando..", null, null, true, MaskType.Black))
            {

                var fileInfo = new FileInfo(file.Path);

                result = await _CustomVision.GetClassifyImage(file);

                if(string.IsNullOrEmpty(result))
                {
                    await DialogService.AlertAsync("Pokedex", "Pokemon não encontrado.", "OK");
                    return;
                }

            }

            //Gambiarra para Navegação do UserDialogs
            await Task.Delay(10);

            var pokemon = await _PokemonService.GetPokemon(result);

            if (pokemon != null)
            {
                var parametros = new NavigationParameters();
                parametros.Add("pokemon", pokemon);

                await NavigationService.NavigateToAsync<PokemonViewModel>(parametros);
            }
        }


    }
}
