using Control;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet4A_Application
{
    public partial class App : Application
    {
        private Controleur control;
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainPage(control));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
