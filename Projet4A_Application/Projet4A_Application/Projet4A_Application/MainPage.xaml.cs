using Modeles;
using System;
using Xamarin.Forms;

namespace Projet4A_Application
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnClickUser(object sender, EventArgs e)
        {
            var user = new Utilisateur { };
            var bibliotheque = new Bibliotheque();
            bibliotheque.BindingContext = user;
            await Navigation.PushAsync(bibliotheque);
            //await Navigation.PushModalAsync(bibliotheque);
        }

        private async void OnClickUserless(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bibliotheque());
           
        }

        private async void OnSettingsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parametres());
        }
    }
}
