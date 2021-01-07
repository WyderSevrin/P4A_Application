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
        }

        protected override void OnAppearing()
        {
            //Write the code of your page here
            setTheme();

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
                CommentaryLabel.TextColor = Color.Black;
                RightPanelLayout.BackgroundColor = Color.AntiqueWhite;
                CommentaryPanelLayout.BackgroundColor = Color.AntiqueWhite;
            }
            else
            {
                FavButton.TextColor = Color.GhostWhite;
                FavButton.BackgroundColor = Color.DarkSeaGreen;
                ReadButton.TextColor = Color.GhostWhite;
                ReadButton.BackgroundColor = Color.DarkSeaGreen;
                NoteItem.TitleColor = Color.GhostWhite;
                DescriptionLabel.TextColor = Color.GhostWhite;
                CommentaryLabel.TextColor = Color.GhostWhite;
                RightPanelLayout.BackgroundColor = Color.DarkSlateBlue;
                CommentaryPanelLayout.BackgroundColor = Color.DarkSlateBlue;
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

            String bookDescription = "Title"; //On recuperera le titre depuis la bdd  
            this.DescriptionLabel.Text = bookDescription;
        }

    }
}