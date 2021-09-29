using ModelTest.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ModelTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}