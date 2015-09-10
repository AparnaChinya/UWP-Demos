using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GeoLocationDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class MainPage : Page
    {
        RandomAccessStreamReference mapIconStreamReference;
        public MainPage()
        {
            this.InitializeComponent();
            myMap.Loaded += myMap_Loaded;
            myMap.MapTapped += MyMap_MapTapped;
            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
        }

        private async void MyMap_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            var getLoc = args.Location.Position;
            string status = "MapTapped at \nLatitude:" + getLoc.Latitude + "\nLongitude: " + getLoc.Longitude;

            var dialog = new MessageDialog("Latitude is " + getLoc.Latitude + " Longitude is " + getLoc.Longitude);
            await dialog.ShowAsync();
        }

        private void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.Center =
               new Geopoint(new BasicGeoposition()
               {
                    //Geopoint for Seattle 
                    Latitude = 47.604,
                   Longitude = -122.329
               });
            myMap.ZoomLevel = 12;
            myMap.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial3D;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = myMap.Center;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "My Friend";
            mapIcon1.Image = mapIconStreamReference;
            mapIcon1.ZIndex = 0;
            myMap.MapElements.Add(mapIcon1);
        }
    }
}
