using Control;
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
    public partial class Parametres : ContentPage
    {
        private Controleur control;

        public Parametres(Controleur control)
        {
            InitializeComponent();
            setTheme();
            this.control = control;
    
        }

        private void OnClairClick(object sender, EventArgs e)
        {
            if (UserSettings.DarkTheme == true)
            {
                UserSettings.DarkTheme = false;
            }
            Full_Layout.BackgroundColor = Color.FromHex("#C7D7FF");
        }

        private void OnSombreClick(object sender, EventArgs e)
        {
            if (UserSettings.DarkTheme == false)
            {
                UserSettings.DarkTheme = true;
            }
            Full_Layout.BackgroundColor = Color.FromHex("#3D2080");
        }

        public void setTheme()
        {
            this.parametre.BackgroundColor = Color.FromHex("#2C5441");
            if (UserSettings.DarkTheme == false)
            {
                Full_Layout.BackgroundColor = Color.FromHex("#C7D7FF");
            }
            else
            {
                Full_Layout.BackgroundColor = Color.FromHex("#3D2080");
            }
        }

    }
}