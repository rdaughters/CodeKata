using System;
using CodeKata.Services;
using CodeKata.ViewModels;
using Xamarin.Forms;
using CodeKata.Views;
using Xamarin.Forms.Xaml;

namespace CodeKata
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPageViewModel viewModel = new MainPageViewModel(new TravelLogStore(), new PageService());
            MainPage = new NavigationPage(new MainPage(viewModel));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
