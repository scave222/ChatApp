using ChatApp.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChatApp.Mobile.Views
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