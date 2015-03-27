namespace BindableApplicationBar.TestApp.ViewModels
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage
        {
            get { return new MainPageViewModel(); }
        }

        public PropertyBindingTestViewModel PropertyBindingTest
        {
            get { return new PropertyBindingTestViewModel(); }
        }
    }
}