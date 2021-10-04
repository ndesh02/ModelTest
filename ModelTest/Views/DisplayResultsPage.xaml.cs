using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ModelTest.Models;

namespace ModelTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayResultsPage : ContentPage
    {
        public DisplayResultsPage()
        {
            InitializeComponent();
            if (Item.results != null)
            {
                try
                {
                    drug1.Text = Item.results["data"]["drugs"][0].ToString();
                    drug2.Text = Item.results["data"]["drugs"][1].ToString();
                    drug3.Text = Item.results["data"]["drugs"][2].ToString();
                    drug4.Text = Item.results["data"]["drugs"][3].ToString();
                    drug5.Text = Item.results["data"]["drugs"][4].ToString();
                    drug6.Text = Item.results["data"]["drugs"][5].ToString();
                }
                catch(Exception ex)
                {

                }
                
            }
            
        }

        private async void Done_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///.///AboutPage");
        }
    }
}