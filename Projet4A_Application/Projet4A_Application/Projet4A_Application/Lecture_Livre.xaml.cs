using Communication;
using Control;
using Modeles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Projet4A_Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lecture_Livre : ContentPage
    {
        private Controleur control;
        private Livre livreToRead;
        public Lecture_Livre(Controleur control, Livre livreToRead)
        {
            InitializeComponent();
            this.control = control;
            this.livreToRead = livreToRead;

  

            String bookTitle = this.livreToRead.titre;  //Variable qui recuperera le nom du livre dans la bdd
            this.Title.Text = bookTitle;

            String bookToReadPath = "Livres/"+ bookTitle + ".pdf";  //Chemin que l'on donne lorsque l'on dl le livre dans le dossier ou sous dossier de Asset

            // this.bookToRead.Uri = Xamarin.Essentials.FileSystem.AppDataDirectory + "/" + bookTitle + ".pdf";//Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), bookTitle+".pdf");
            //this.bookToRead.Uri = "storage/emulated/0/Download/"+ bookTitle + ".pdf"; //"Livres /test.pdf";

            Console.WriteLine("\n Livre a lire avec chemin statique" + ftpPaths.pathMobile);
            this.bookToRead.Uri = ftpPaths.pathMobile+bookTitle+".pdf";
            //this.bookToRead.Uri = "/storage/emulated/0/Download/Au_Soleil_Maupassant.pdf";
            
            
        }

        private void OnPreviousClick(object sender, EventArgs e)
        {

        }

        private void OnNextClick(object sender, EventArgs e)
        {

        }
    }
}