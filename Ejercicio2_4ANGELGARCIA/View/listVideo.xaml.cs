using Ejercicio2_4ANGELGARCIA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4ANGELGARCIA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listVideo : ContentPage
    {
        public listVideo()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaVideo.ItemsSource = await App.BD.getListVideo();
        }
        Video video;
        private async void listVideo_ItemTapped(object sender, ItemTappedEventArgs e)
        {
             video = (Video)e.Item;

            await Navigation.PushAsync(new VerVideo(this.video));
        }

       

    }
}