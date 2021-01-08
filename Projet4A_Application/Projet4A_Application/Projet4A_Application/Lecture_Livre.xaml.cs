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
    public partial class Lecture_Livre : ContentPage
    {
        public Lecture_Livre()
        {
            InitializeComponent();
            String bookTitle = "Title";  //Variable qui recuperera le nom du livre dans la bdd
            this.Title.Text = bookTitle;

            String bookToReadPath = "Livres/test.pdf";  //Chemin que l'on donne lorsque l'on dl le livre dans le dossier ou sous dossier de Asset
            this.bookToRead.Uri = bookToReadPath;
        }

        private void OnPreviousClick(object sender, EventArgs e)
        {

        }

        private void OnNextClick(object sender, EventArgs e)
        {

        }
    }
}