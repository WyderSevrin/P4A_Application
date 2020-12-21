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
        }

        private async void OnSettingsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parametres());
        }

        private async void GoReadPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lecture_Livre());
        }
        private async void HtmlTestClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EpubReader());
        }

    }
}