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
    public partial class Profile_Livre : ContentPage
    {
        private Controleur control;
        private Livre livreToRead;

        private List<Commentaire> listCommentaire;

        public Profile_Livre(Controleur control, Livre livreToread)
        {
            InitializeComponent();
            this.control = control;
            this.livreToRead = livreToread;
            this.control.updateListCommentaireById(this.livreToRead.id.ToString());
            this.listCommentaire = this.control.commentaires;
            
            setTheme();
            setItem();
            setCommentaryStack();

            
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();
            setItem();

            this.control.updateListCommentaire();
            this.listCommentaire = this.control.commentaires;

            //setCommentaryStack();

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
                RightPanelLayout.BackgroundColor = Color.FromHex("#019855");
                CommentaryPanelLayout.BackgroundColor = Color.FromHex("#E6F0D5");
                CommentaryLabel.TextColor = Color.Black;
                ScrollingCommentary.BackgroundColor = Color.FromHex("#E6F0D5");
                this.CommentaryEntry.PlaceholderColor = Color.Black;
                this.CommentaryEntry.TextColor = Color.Black;
            }
            else
            {
                FavButton.TextColor = Color.GhostWhite;
                FavButton.BackgroundColor = Color.DarkSeaGreen;
                ReadButton.TextColor = Color.GhostWhite;
                ReadButton.BackgroundColor = Color.DarkSeaGreen;
                NoteItem.TitleColor = Color.Yellow;
                DescriptionLabel.TextColor = Color.GhostWhite;
                RightPanelLayout.BackgroundColor = Color.FromHex("#3D5080");
                CommentaryPanelLayout.BackgroundColor = Color.FromHex("#636B80");
                CommentaryLabel.TextColor = Color.GhostWhite;
                ScrollingCommentary.BackgroundColor = Color.FromHex("#7AA0FF");
                this.CommentaryEntry.PlaceholderColor = Color.White;
                this.CommentaryEntry.TextColor = Color.White;
            }
        }

        private async void ReadButton_Clicked(object sender, EventArgs e)
        {
           /* 
            Device.BeginInvokeOnMainThread(() =>
            {
                DependencyService.Get<Toast>().Show("Téléchargement du Livre");
            });*/
            // DependencyService.Get<Toast>().Show("Téléchargement du Livre");

            //Télécharger le livre
            this.control.downLoadLivre(this.livreToRead.id);

            //On passe à l'affichage
            await Navigation.PushAsync(new Lecture_Livre(this.control,this.livreToRead));
        }

        public void setItem()
        {
            String bookTitle = this.livreToRead.titre; //On recuperera le titre depuis la bdd  
            this.TitreLivre.Text = bookTitle;
            this.TitreLivre.BackgroundColor = Color.FromHex("#2C5441");
            String bookDescription = this.livreToRead.resumer; //On recuperera le titre depuis la bdd  
            this.DescriptionLabel.Text = bookDescription;

            String NoteTitle = "5"; //On recupere la note moyenne depuis la bdd
            this.NoteItem.Title = NoteTitle;

            ScrollingCommentary.HeightRequest = CommentaryPanelLayout.Height - CommentaryPanelLayout.Height / 10;
            ReadButton.WidthRequest = RightPanelLayout.Width / 3;
            FavButton.WidthRequest = RightPanelLayout.Width / 3;
            NoteItem.WidthRequest = RightPanelLayout.Width / 3;
        }


        public void setCommentaryStack()
        {
            this.CommentaryDisplayer.Children.Clear();
            

            for (int i = 0; i < this.listCommentaire.Count(); i++)
            {


                var UserPseudo = new Label()
                {
                    Text = this.control.getAuteurCommentaire(this.listCommentaire[i].idUtilisateur.ToString()), //Recuperer le pseudo de la personne qui commente dans la bdd
                    Margin = new Thickness(0, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                var Commentary = new Label
                {
                    Text = this.listCommentaire[i].contenu, //Recuperer le nom du livre dans une bdd
                    Margin = new Thickness(0, 0, 0, 0),
                    FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label))
                };

                if (UserSettings.DarkTheme == false)
                {
                    UserPseudo.BackgroundColor = Color.FromHex("#E6F0D5");
                    UserPseudo.TextColor = Color.Black;
                    Commentary.TextColor = Color.Black;

                }
                else
                {
                    UserPseudo.BackgroundColor = Color.FromHex("#6280CC");
                    UserPseudo.TextColor = Color.GhostWhite;
                    Commentary.TextColor = Color.GhostWhite;
                }

                this.CommentaryDisplayer.Children.Add(UserPseudo);
                this.CommentaryDisplayer.Children.Add(Commentary);

            }
        }
        private void SendCommentaire(object sender, EventArgs e)
        {
            if (this.CommentaryEntry.Text == "" || this.CommentaryEntry.Text == "")
            {
                String CommentaireToSend = this.CommentaryEntry.Text;
                //Fonction pour envoyer un commentaire
                this.CommentaryEntry.Text = "";
            }
        }

    }
}