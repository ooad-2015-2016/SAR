﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobilnaAplikacijaKorisnik
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageRadnaPovrsina : Page
    {
        public PageRadnaPovrsina()
        {
            this.InitializeComponent();
            BasicGeoposition cityGeoposition = new BasicGeoposition() { Latitude = 43.858929, Longitude= 18.415170 };
            Geopoint sarajevoCentar = new Geopoint(cityGeoposition);
            MapaTaxi.Center = sarajevoCentar;
            MapaTaxi.ZoomLevel = 15;

        }
        void GoBack()
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
