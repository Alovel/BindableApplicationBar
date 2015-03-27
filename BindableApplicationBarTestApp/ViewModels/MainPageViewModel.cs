using BindableApplicationBar.TestApp.Services;

namespace BindableApplicationBar.TestApp.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        #region GoToPropertyBindingTestPage
        private DelegateCommand goToPropertyBindingTestPageCommand;
        public DelegateCommand GoToPropertyBindingTestPageCommand
        {
            get
            {
                return goToPropertyBindingTestPageCommand ?? (goToPropertyBindingTestPageCommand = new DelegateCommand(GoToPropertyBindingTestPage, CanGoToPropertyBindingTestPage));
            }
        }

        private static void GoToPropertyBindingTestPage(object parameter)
        {
            PageNavigation.GoToPropertyBindingTestPage();
        }

        private static bool CanGoToPropertyBindingTestPage(object parameter)
        {
            return true;
        }
        #endregion
    }
}