using ModelTest.Services;
using ModelTest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModelTest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Plugin.Media.CrossMedia.Current.Initialize();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
