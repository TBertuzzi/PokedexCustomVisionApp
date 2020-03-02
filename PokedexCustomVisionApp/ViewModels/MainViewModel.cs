using System;
using System.Threading.Tasks;
using Xamarin.Forms.MVVMBase.ViewModels;

namespace PokedexCustomVisionApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        public MainViewModel() : base("Pokedex")
        {
        }

     
        public override async Task LoadAsync(object navigationData)
        {

        }
    }
}
