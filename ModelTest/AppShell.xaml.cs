using ModelTest.ViewModels;
using ModelTest.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ModelTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(TakePhotoPage), typeof(TakePhotoPage));
            Routing.RegisterRoute(nameof(DisplayResultsPage), typeof(DisplayResultsPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
