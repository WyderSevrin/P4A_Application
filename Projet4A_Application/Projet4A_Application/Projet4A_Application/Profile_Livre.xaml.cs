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
    public partial class Profile_Livre : ContentPage
    {
        public Profile_Livre()
        {
            InitializeComponent();
            setTheme();
            setItem();
            setCommentaryStack();
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();
            setItem();
            setCommentaryStack();

            base.OnAppearing();
        }

        private void OnFavClick(object sender, EventArgs e)
        {

        }

        public void setTheme()
        {
            if (UserSettings.DarkTheme == false)
            {
                FavButton.TextColor = Color.Black;
                FavButton.BackgroundColor = Color.LightGray;
                ReadButton.TextColor = Color.Black;
                ReadButton.BackgroundColor = Color.LightGray;
                NoteItem.TitleColor = Color.Black;
                DescriptionLabel.TextColor = Color.Black;
                RightPanelLayout.BackgroundColor = Color.AntiqueWhite;
                CommentaryPanelLayout.BackgroundColor = Color.LightSteelBlue;
                CommentaryLabel.TextColor = Color.Black;
                ScrollingCommentary.BackgroundColor = Color.LightSteelBlue;
            }
            else
            {
                FavButton.TextColor = Color.GhostWhite;
                FavButton.BackgroundColor = Color.DarkSeaGreen;
                ReadButton.TextColor = Color.GhostWhite;
                ReadButton.BackgroundColor = Color.DarkSeaGreen;
                NoteItem.TitleColor = Color.GhostWhite;
                DescriptionLabel.TextColor = Color.GhostWhite;
                RightPanelLayout.BackgroundColor = Color.DarkSlateBlue;
                CommentaryPanelLayout.BackgroundColor = Color.DarkBlue;
                CommentaryLabel.TextColor = Color.GhostWhite;
                ScrollingCommentary.BackgroundColor = Color.DarkBlue;
            }
        }

        private async void ReadButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lecture_Livre());
        }

        public void setItem()
        {
            String bookTitle = "Title"; //On recuperera le titre depuis la bdd  
            this.TitreLivre.Text = bookTitle;

            String bookDescription = "Resume du bouquin"; //On recuperera le titre depuis la bdd  
            this.DescriptionLabel.Text = bookDescription;

            String NoteTitle = "Note"; //On recupere la note moyenne depuis la bdd
            this.NoteItem.Title = NoteTitle;

            ScrollingCommentary.HeightRequest = CommentaryPanelLayout.Height - CommentaryPanelLayout.Height / 10;
            ReadButton.WidthRequest = RightPanelLayout.Width / 3;
            FavButton.WidthRequest = RightPanelLayout.Width / 3;
            NoteItem.WidthRequest = RightPanelLayout.Width / 3;
        }


        public void setCommentaryStack()
        {
            this.CommentaryDisplayer.Children.Clear();


            for (int i = 0; i < 20; i++)
            {


                var UserPseudo = new Label()
                {
                    Text = "XX_Pseudo_XX", //Recuperer le pseudo de la personne qui commente dans la bdd
                    Margin = new Thickness(0, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                var Commentary = new Label
                {
                    Text = "Ce livre c'est de la merde. Et puis bon qu'est-ce qu'un livre. Un rammasis d'encre sur un ramassis de papier. Enfin plus maintenant", //Recuperer le nom du livre dans une bdd
                    Margin = new Thickness(0, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                if (UserSettings.DarkTheme == false)
                {
                    UserPseudo.BackgroundColor = Color.LightGray;
                    UserPseudo.TextColor = Color.Black;
                    Commentary.TextColor = Color.Black;
                }
                else
                {
                    UserPseudo.BackgroundColor = Color.DarkSeaGreen;
                    UserPseudo.TextColor = Color.GhostWhite;
                    Commentary.TextColor = Color.GhostWhite;
                }

                this.CommentaryDisplayer.Children.Add(UserPseudo);
                this.CommentaryDisplayer.Children.Add(Commentary);

            }
        }

    }
}