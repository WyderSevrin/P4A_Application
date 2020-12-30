using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet4A_Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bibliotheque : ContentPage
    {
        public Bibliotheque()
        {
            InitializeComponent();
            setTheme();
            setStack();
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();
            setStack();

            base.OnAppearing();
        }

        private async void OnSettingsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parametres());
        }

        private async void GoReadPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile_Livre());
        }

        private async void HtmlTestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EpubReader());
        }

        private void setTheme()
        {
            if (UserSettings.DarkTheme == false)
            {
                ScrollingItem.BackgroundColor = Color.AntiqueWhite;
            }
            else
            {
                ScrollingItem.BackgroundColor = Color.DarkSlateBlue;
            }
        }

        private void setStack()
        {
            StackTest.Children.Clear();


            for (int i = 0; i < 10; i++)
            {
                var flexLaytest = new FlexLayout()
                {

                };
                flexLaytest.Direction = FlexDirection.Row;

                var accesBookButton = new Button()
                {
                    Text = "Acceder",
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label)),
                };

                var TitreLivre = new Label
                {
                    Text = "Nom du livre",
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                var NomAuteur = new Label
                {
                    Text = "Nom de l'auteur",
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                if (UserSettings.DarkTheme == false)
                {
                    accesBookButton.BackgroundColor = Color.LightGray;
                    accesBookButton.TextColor = Color.Black;
                    TitreLivre.TextColor = Color.Black;
                    NomAuteur.TextColor = Color.Black;
                }
                else
                {
                    accesBookButton.BackgroundColor = Color.DarkSeaGreen;
                    accesBookButton.TextColor = Color.GhostWhite;
                    TitreLivre.TextColor = Color.GhostWhite;
                    NomAuteur.TextColor = Color.GhostWhite;
                }

                accesBookButton.Clicked += GoReadPage;

                flexLaytest.Children.Add(NomAuteur);
                flexLaytest.Children.Add(TitreLivre);
                flexLaytest.Children.Add(accesBookButton);

                StackTest.Children.Add(flexLaytest);

            }
        }
    }
}