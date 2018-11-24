using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Podify.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Podify
{
    public partial class App : Application
    {
        private NavigationPage _navigationManager;

        public static App AppRoot => (App)Current;
        public static NavigationPage NavigationManager { get => AppRoot?._navigationManager; }

        public App()
        {
            InitializeComponent();

            _navigationManager = new NavigationPage(new PodcastSearchPage());
            MainPage = _navigationManager;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
