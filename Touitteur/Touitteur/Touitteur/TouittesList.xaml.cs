using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touitteur.Models;
using Touitteur.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Touitteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TouittesList : ContentPage
    {
        private ITouitteurService touitteurService;
        public List<Touitte> Touittes { get; private set; }

        public TouittesList()
        {
            InitializeComponent();
            touitteurService = TouitteurService.GetInstance();
            Touittes = touitteurService.GetTouittes("");
            TouitteList.ItemsSource = Touittes;
        }

        private async void TouitteList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var touitte = (Touitte)TouitteList.SelectedItem;
            await Navigation.PushAsync(new Detail(touitte));
        }
    }

    
}