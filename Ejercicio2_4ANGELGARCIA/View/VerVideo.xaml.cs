using Ejercicio2_4ANGELGARCIA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4ANGELGARCIA.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerVideo : ContentPage
    {
        public VerVideo(Video video)
        {
            InitializeComponent();
            verVideo(video);
        }

        public void verVideo(Video video)
        {
            UriVideoSource uri = new UriVideoSource()
            {
                Uri = video.url
            };
            verPlay.Source = uri;
        }
    }
}