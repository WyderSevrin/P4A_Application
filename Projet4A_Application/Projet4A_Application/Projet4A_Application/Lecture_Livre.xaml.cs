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
            this.yep.Uri = "Livres/test.pdf";
        }

        private void OnPreviousClick(object sender, EventArgs e)
        {

        }

        private void OnNextClick(object sender, EventArgs e)
        {

        }
    }
}