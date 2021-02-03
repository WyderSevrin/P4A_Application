using Control;
using Modeles;
using System;
using Xamarin.Forms;

namespace Projet4A_Application
{
    public partial class MainPage : ContentPage
    {
        private Controleur control;

        public MainPage(Controleur control)
        {
            InitializeComponent();
            this.control = control;
            setItem();
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();
            setItem();
            base.OnAppearing();
        }

        private async void OnClickUser(object sender, EventArgs e)
        {
            int userID = int.Parse(CodeEntry.Text);
            var user = new Utilisateur();
            var bibliotheque = new Bibliotheque(this.control);
            bibliotheque.BindingContext = user;
            await Navigation.PushAsync(bibliotheque);
        }

        private async void OnClickUserless(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Bibliotheque(this.control));
        }

        private async void OnSettingsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parametres(control));
        }

        private void setTheme()
        {
            if (UserSettings.DarkTheme == false)
            {
                this.BackgroundColor = Color.FromHex("#C7D7FF");
                EBiblioLayout.BackgroundColor = Color.ForestGreen;
                CodeEntry.BackgroundColor = Color.LightGray;
                CodeEntry.PlaceholderColor = Color.Black;
                NextButton.BackgroundColor = Color.LightGray;
                NextButton.TextColor = Color.Black;
                InviteeButton.BackgroundColor = Color.LightGray;
                InviteeButton.TextColor = Color.Black;
                SettingsButton.BackgroundColor = Color.LightGray;
                SettingsButton.TextColor = Color.Black;
            }
            else
            {
                this.BackgroundColor = Color.FromHex("#3D5080");
                EBiblioLayout.BackgroundColor = Color.FromHex("#6280CC");
                CodeEntry.BackgroundColor = Color.FromHex("#6336B80");
                CodeEntry.PlaceholderColor = Color.GhostWhite;
                NextButton.BackgroundColor = Color.FromHex("#6336B80");
                NextButton.TextColor = Color.GhostWhite;
                InviteeButton.BackgroundColor = Color.FromHex("#6336B80");
                InviteeButton.TextColor = Color.GhostWhite;
                SettingsButton.BackgroundColor = Color.FromHex("#6336B80");
                SettingsButton.TextColor = Color.GhostWhite;
            }
        }

        public void setItem()
        {

            

        }

    }
}
