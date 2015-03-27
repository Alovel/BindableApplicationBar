using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace BindableApplicationBar.TestApp.Services
{
    public static class PageNavigation
    {
        private static PhoneApplicationFrame frame;
        private static PhoneApplicationFrame Frame
        {
            get { return frame ?? (frame = (PhoneApplicationFrame)Application.Current.RootVisual); }
        }

        public static void GoToPropertyBindingTestPage()
        {
            Frame.Navigate(new Uri("/Views/PropertyBindingTestPage.xaml", UriKind.Relative));
        }
    }
}