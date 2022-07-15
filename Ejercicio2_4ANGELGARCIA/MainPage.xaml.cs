using Ejercicio2_4ANGELGARCIA.Model;
using Ejercicio2_4ANGELGARCIA.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ejercicio2_4ANGELGARCIA
{
    public partial class MainPage : ContentPage
    {
        bool validarvideo = false;
        public MainPage()
        {
            InitializeComponent();
            if (App.BD != null) { }
        }
        public string PhotoPath;
        private async void btnGrabar_Clicked(object sender, EventArgs e)
        {

            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return; 
            }

            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                await VideoLoad(video);
                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;
                validarvideo = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }

        }

        async Task VideoLoad(FileResult video)
        {
            if (video == null)
            {
                PhotoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Alerta", "Por favor, ingrese una descripcion", "OK");
                return;
            }

            if (!validarvideo)
            {
                await DisplayAlert("Alerta", "Por favor grabe el video", "OK");
                return;
            }

              var videos = new Video
                {
                    id = 0,
                    url = PhotoPath,
                    descripcion = txtDescripcion.Text,
                    fecha = DateTime.Now
                };

                var result = await App.BD.insertUpdateVideo(videos);

                if (result > 0)
                {
                    await DisplayAlert("", "Video Guardado", "OK");
                    videoPlayer.Source = null;
                    txtDescripcion.Text = "";
                    
                }
                else
                {
                    await DisplayAlert("Error", "erro al guardar video", "OK");
                }
            
        }

        private async void btnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listVideo());
        }
    }
}
