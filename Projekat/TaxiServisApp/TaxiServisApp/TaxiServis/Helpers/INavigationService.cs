using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TaxiServisApp.TaxiServis.Helpers
{
    interface INavigationService
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
       // void Navigate(Type type, MainPageViewModel mainPageViewModel, Korisnik korisnik);
       // void Navigate(Type type, MainPageViewModel mainPageViewModel);
    }
}
class NavigationService : INavigationService
{
    //obicna navigacija bez parametra
    public void Navigate(Type sourcePage)
    {
        var frame = (Frame)Window.Current.Content;
        frame.Navigate(sourcePage);
    }
    //navigiranje na page ali da se proslijedi parametar stranici
    public void Navigate(Type sourcePage, object parameter1)
    {
        var frame = (Frame)Window.Current.Content;
        frame.Navigate(sourcePage, parameter1);
    }
 /*   public void Navigate(Type sourcePage, object parameter1, Korisnik parameter2)
    {
        var frame = (Frame)Window.Current.Content;
        frame.Navigate(sourcePage, parameter1, parameter2);
    }*/
    //poziv da se vrati na predhodnu stranicu
    public void GoBack()
    {
        var frame = (Frame)Window.Current.Content;
        frame.GoBack();
    }


}
