using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace TaxiServisApp.TaxiServis.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    //_______________________SS-komentar______________________________
    //nisa napravila bas sve sto trebalo sto se tice  dizajna jer nije htjelo da se pokrene, 
    //al to cemo rijesiti sljedeci put
    //ovdje imamo na vrhu glavne kontrole gdje ovo dugme nazad vrati na pocetnu formu
    //za ostale funkcionalnosti se trebamo dogovorit sta da dodam i sta to da radi
    // npr kako ce on obavjestiti sve slobodne taxije da li ce to biti tako da 
    // se u text box ukuca adresa pa svi dobiju tu obavijest ili ??
    public sealed partial class PocetnaDispecerView : Page
    {
        public PocetnaDispecerView()
        {
            this.InitializeComponent();
        }
        //_______________________SS-komentar______________________________
        //event za klik za Nazad button
        private void nazadButton_Click(object sender, RoutedEventArgs e)
        {
            //_______________________SS-komentar______________________________
            // da se vrati nazad na log in stranicu this.Frame.GoBack(); u slucaju
            //da otvaramo sa this.Frame.Navigate(typeoff...)
        }
    }
}
