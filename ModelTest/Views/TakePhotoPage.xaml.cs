using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ModelTest.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace ModelTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakePhotoPage : ContentPage
    {
        
        public Image photo;
        public JObject form = new JObject();
        public TakePhotoPage()
        {
            InitializeComponent();
            if(PhotoImage.Source == null)
            {
                Continue.IsEnabled = false;
            }
            if(Item.isInitialized == false)
                Item.Initialize();
        }
        //PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight, MaxWidthHeight = 600
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            CameraButton.IsEnabled = false;
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            Console.WriteLine(photo.GetStream());
            Console.WriteLine(photo.GetStream().GetType());
            byte[] imageData = new byte[photo.GetStream().Length];
            Console.WriteLine(imageData.Length);
            Console.WriteLine(photo.GetStream().Length);
            await photo.GetStream().ReadAsync(imageData, 0, Convert.ToInt32(photo.GetStream().Length));
            Console.WriteLine(imageData);
            form["Imagedata"] = Convert.ToBase64String(imageData);
            if(photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                Continue.IsEnabled = true;
            }
            CameraButton.IsEnabled = true;
        }

        private async void Continue_Clicked(object sender, EventArgs e)
        {
            CameraButton.IsEnabled = false;
            Continue.IsEnabled = false;
            try
            {
                var res1 = await Item.imageClient.GetAsync("/");
            }catch(Exception ex)
            {

            }
            form["CustomerLogin"] = "1";
            form["LotNumber"] = LotNumber.Text;
            form["SpecimenId"] = "2021";
            form["SaveImage"] = "true";
            form["ImageFormat"] = "png";
            form["UserName"] = "ansh.sahny";
            form["Password"] = "Ansh1806";
            form["Transform"] = "true";
            form["IsFaint"] = "true";
            Console.WriteLine(form["Imagedata"]);
            var image = form["Imagedata"];
            AboutPage.GetWifiPermission();
            var res = await Item.imageClient.PostAsync("strip-reader", new StringContent(form.ToString(), System.Text.Encoding.UTF8, "application/json"));
            var resString = await res.Content.ReadAsStringAsync();
            try
            {
                Item.results = JObject.Parse(resString);
            }
            catch(Exception ex)
            {
                Item.results = null;
            }
            CameraButton.IsEnabled = true;
            Continue.IsEnabled = true;
            PhotoImage.Source = null;
            await Shell.Current.GoToAsync("DisplayResultsPage");
        }
    }
}