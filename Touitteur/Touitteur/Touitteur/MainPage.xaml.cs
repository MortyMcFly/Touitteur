using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touitteur.Models;
using Touitteur.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Touitteur
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ITouitteurService touitteurService;
        public List<Touitte> Touittes { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            touitteurService = TouitteurService.GetInstance();
        }

        private void BtnConnection_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked !!!");

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ErrorMessage.Text = "Veuillez vous connecter aux internets";
            }

            else if (string.IsNullOrEmpty(InputPseudo.Text) || string.IsNullOrEmpty(InputPassword.Text))
            {
                ErrorMessage.Text = "Merci de saisir un identifiant et un mot de passe stp";
            }

            else if (InputPseudo.Text.Length < 3)
            {
                ErrorMessage.Text = "Identifiant trop couuuurt !";
            }

            else if (InputPassword.Text.Length < 6)
            {
                ErrorMessage.Text = "Mot de passe trop couuuurt !";
            }

            else if (touitteurService.Authenticate(InputPseudo.Text, InputPassword.Text))
            {
                Touittes = touitteurService.GetTouittes("");
                TouitteList.ItemsSource = Touittes;
                LoginView.IsVisible = false;
                TouitteList.IsVisible = true;
            }

            else
            {
                ErrorMessage.Text = "Identifiant ou mot de passe incorrect cheh";
            }
        }

        private async void TouitteList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var touitte = (Touitte)TouitteList.SelectedItem;
            await Navigation.PushAsync(new Detail(touitte));
        }
    }
}
