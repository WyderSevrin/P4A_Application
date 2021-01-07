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
        public Parametres()
        {
            InitializeComponent();
            setTheme();
        }

        private void OnClairClick(object sender, EventArgs e)
        {
            if (UserSettings.DarkTheme == true)
            {
                UserSettings.DarkTheme = false;
            }
            Full_Layout.BackgroundColor = Color.LightGray;
        }

        private void OnSombreClick(object sender, EventArgs e)
        {
            if (UserSettings.DarkTheme == false)
            {
                UserSettings.DarkTheme = true;
            }
            Full_Layout.BackgroundColor = Color.DarkSlateBlue;
        }

        public void setTheme()
        {
            if (UserSettings.DarkTheme == false)
            {
                Full_Layout.BackgroundColor = Color.LightGray;
            }
            else
            {
                Full_Layout.BackgroundColor = Color.DarkSlateBlue;
            }
        }

    }
}