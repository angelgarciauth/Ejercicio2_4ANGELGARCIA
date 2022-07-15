using Ejercicio2_4ANGELGARCIA.Controller;
using Ejercicio2_4ANGELGARCIA.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4ANGELGARCIA
{
    public partial class App : Application
    {
        static BaseDatos BaseDatos;

        public static BaseDatos BD
        {
            get
            {
                if (BaseDatos == null)
                {
                    BaseDatos = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Videos.db3"));
                }
                return BaseDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
