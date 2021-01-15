using Control;
using Modeles;
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
        private Controleur control;

        public Bibliotheque(Controleur control)
        {
            InitializeComponent();
            this.control = control;
            this.control.CurrentBookStack = this.control.Bibliotheque;
            setTheme();
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();
            setStack(control.Bibliotheque);
            this.control.CurrentBookStack = this.control.Bibliotheque;
            base.OnAppearing();
        }

        private async void OnSettingsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parametres(control));
        }

        private async void GoReadPage(object sender, EventArgs e)
        {
            var selectedBookTitle = ((Button)sender).ClassId;
            for (int i = 0; i<this.control.CurrentBookStack.Count; i++)
            {
                if (this.control.CurrentBookStack[i].titre == selectedBookTitle)
                {
                    this.control.SelectedBook = this.control.CurrentBookStack[i];
                }
            }
            await Navigation.PushAsync(new Profile_Livre(control));
        }

        private async void HtmlTestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EpubReader());
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            if (NameEntry.Text == null || NameEntry.Text == "") {
                setStack(control.Bibliotheque);
                this.control.CurrentBookStack = this.control.Bibliotheque;
            }
            else
            {
                setStack(control.searchLivreByNom(NameEntry.Text.ToString()));
                this.control.CurrentBookStack = control.searchLivreByNom(NameEntry.Text.ToString());
            }
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

        private void setStack(List<Livre> livre)
        {
            StackTest.Children.Clear();



            for (int i = 0; i < livre.Count; i++)
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
                    WidthRequest = this.Width / 3,
                    ClassId = livre[i].titre
                };

                var TitreLivre = new Label
                {
                    Text = livre[i].titre, //Recuperer le nom du livre dans une bdd
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label)),
                    WidthRequest = this.Width / 3
                };

                var NomAuteur = new Label
                {
                    Text = "Auteur",  //Recuperer le nom de l'auteur dans une bdd
                    Margin = new Thickness(10, 0, 10, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label)),
                    WidthRequest = this.Width / 3
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

        private void GenreChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            List<Livre> listLivre = control.searchLivreByGenre(Genre_Picker.SelectedItem.ToString());
            setStack(listLivre);
            this.control.CurrentBookStack = listLivre;
        }

        private void MouvementChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            List<Livre> listLivre = control.searchLivreByGenre(Mouvement_Picker.SelectedItem.ToString());
            setStack(listLivre);
            this.control.CurrentBookStack = listLivre;
        }

        private void FavCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void OrdreChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}