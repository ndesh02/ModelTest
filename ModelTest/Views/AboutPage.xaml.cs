using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModelTest.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            logo.Source = ImageSource.FromResource("ModelTest.Images.RapidResponseLogo2.png");
        }

        public async Task<bool> GetCameraPermission()
        {
            try
            {

                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

                if (status != PermissionStatus.Granted)
                {


                    status = await Permissions.RequestAsync<Permissions.Camera>();
                }

                if (status == PermissionStatus.Granted)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        private async void Photo_Clicked(object sender, EventArgs e)
        {
            await GetCameraPermission();
            await Shell.Current.GoToAsync("TakePhotoPage");
        }
    }
}