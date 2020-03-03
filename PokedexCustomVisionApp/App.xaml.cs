using System;
using PokedexCustomVisionApp.Services;
using PokedexCustomVisionApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.MVVMBase.Services.Navigation;
using Xamarin.Forms.MVVMBase.ViewModels;
using Xamarin.Forms.Xaml;

namespace PokedexCustomVisionApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BuildDependencies();
            InitNavigation();
        }

        public void BuildDependencies()
        {
            ViewModelLocator.Current.RegisterForNavigation<MainPage, MainViewModel>();
            ViewModelLocator.Current.RegisterForNavigation<PokemonView, PokemonViewModel>();

            //registrando os serviços
            ViewModelLocator.Current.Register<IPokemonService, PokemonService>();
            ViewModelLocator.Current.Register<ICustomVision, CustomVisionService>();
        }

        async void InitNavigation()
        {
            var navigationService = ViewModelLocator.Current.Resolve<INavigationService>();
            await navigationService.InitializeAsync<MainViewModel>(null, true);
        }
    }
}
