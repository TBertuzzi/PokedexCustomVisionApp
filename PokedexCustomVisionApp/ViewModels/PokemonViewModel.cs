using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using PokedexCustomVisionApp.Helpers;
using PokedexCustomVisionApp.Models;
using PokedexCustomVisionApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.MVVMBase.Services.Navigation;
using Xamarin.Forms.MVVMBase.ViewModels;

namespace PokedexCustomVisionApp.ViewModels
{
    public class PokemonViewModel : BaseViewModel
    {
        public ICommand VoltarCommand { get; }

        private Pokemon _pokemon;
        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set
            {
                SetProperty(ref _pokemon, value);
            }
        }


        public PokemonViewModel() : base("Pokemon")
        {
            VoltarCommand = new Command(ExecuteVoltarCommand);
            Pokemon = new Pokemon();
        }

        private async void ExecuteVoltarCommand()
        {
            await NavigationService.NavigateBackAsync();
        }
        
        public override async Task LoadAsync(NavigationParameters navigationData)
        {
            try
            {
                if (navigationData != null &&
                    navigationData.ContainsKey("pokemon"))
                {
                    Pokemon = navigationData["pokemon"].Cast<Pokemon>();

                    await TextToSpeech.SpeakAsync(Pokemon.Description);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
