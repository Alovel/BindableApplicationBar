using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BindableApplicationBar.TestApp.ViewModels
{
    public class PropertyBindingTestViewModel : ViewModel
    {
        private const int XamlDefinedButtonsCount = 2;
        private const int XamlDefinedMenuItemsCount = 2;
        private readonly List<ApplicationBarIconButton> nonBindableButtons = new List<ApplicationBarIconButton>();
        private readonly List<ApplicationBarMenuItem> nonBindableMenuItems = new List<ApplicationBarMenuItem>();
        
        #region IconUri
        private Uri iconUri = new Uri("/Icons/Dark/appbar.add.rest.png", UriKind.RelativeOrAbsolute);

        public Uri IconUri
        {
            get
            {
                if(FirstIconChoice)
                {
                    this.iconUri = new Uri("/Icons/Dark/appbar.add.rest.png", UriKind.RelativeOrAbsolute);
                }

                if(SecondIconChoice)
                {
                    this.iconUri = new Uri("/Icons/Dark/appbar.minus.rest.png", UriKind.RelativeOrAbsolute);
                }

                return this.iconUri;
            }
        }
        #endregion

        #region FirstIconChoice
        private bool firstIconChoice = true;

        public bool FirstIconChoice
        {
            get { return this.firstIconChoice; }
            set
            {
                if(this.firstIconChoice != value)
                {
                    this.firstIconChoice = value;
                    RaisePropertyChanged("FirstIconChoice");
                    RaisePropertyChanged("IconUri");
                }
            }
        }
        #endregion

        #region SecondIconChoice
        private bool secondIconChoice;

        public bool SecondIconChoice
        {
            get { return this.secondIconChoice; }
            set
            {
                if(this.secondIconChoice != value)
                {
                    this.secondIconChoice = value;
                    RaisePropertyChanged("SecondIconChoice");
                    RaisePropertyChanged("IconUri");
                }
            }
        }
        #endregion

        #region IconButtonText
        private string iconButtonText = "XAML Btn 1";

        public string IconButtonText
        {
            get { return this.iconButtonText; }
            set
            {
                if(this.iconButtonText != value)
                {
                    this.iconButtonText = value;
                    RaisePropertyChanged("IconButtonText");
                }
            }
        }
        #endregion

        #region MenuItemText
        private string menuItemText = "XAML MnuIt 1";

        public string MenuItemText
        {
            get { return this.menuItemText; }
            set
            {
                if(this.menuItemText != value)
                {
                    this.menuItemText = value;
                    RaisePropertyChanged("MenuItemText");
                }
            }
        }
        #endregion

        #region BarIsVisible
        private bool barIsVisible = true;

        public bool BarIsVisible
        {
            get { return this.barIsVisible; }
            set
            {
                if(this.barIsVisible != value)
                {
                    this.barIsVisible = value;
                    RaisePropertyChanged("BarIsVisible");
                }
            }
        }
        #endregion

        #region Opacity
        private double opacity = 0.75;

        public double Opacity
        {
            get { return this.opacity; }
            set
            {
                if(this.opacity != value)
                {
                    this.opacity = value;
                    RaisePropertyChanged("Opacity");
                }
            }
        }
        #endregion

        #region ForegroundColor
        private double foregroundColor = 0.90;

        public double ForegroundColor
        {
            get { return this.foregroundColor; }
            set
            {
                if(this.foregroundColor != value)
                {
                    this.foregroundColor = value;
                    RaisePropertyChanged("ForegroundColor");
                }
            }
        }
        #endregion

        #region BackgroundColor
        private double backgroundColor = 0.001;

        public double BackgroundColor
        {
            get { return this.backgroundColor; }
            set
            {
                if(this.backgroundColor != value)
                {
                    this.backgroundColor = value;
                    RaisePropertyChanged("BackgroundColor");
                }
            }
        }
        #endregion

        #region IsMenuVisible
        private bool isMenuVisible;

        public bool IsMenuVisible
        {
            get { return this.isMenuVisible; }
            set
            {
                if(this.isMenuVisible != value)
                {
                    this.isMenuVisible = value;
                    RaisePropertyChanged("IsMenuVisible");
                }
            }
        }
        #endregion

        #region IsMenuEnabled
        private bool isMenuEnabled = true;

        public bool IsMenuEnabled
        {
            get { return this.isMenuEnabled; }
            set
            {
                if(this.isMenuEnabled != value)
                {
                    this.isMenuEnabled = value;
                    RaisePropertyChanged("IsMenuEnabled");
                }
            }
        }
        #endregion

        #region ModeBool
        private bool modeBool = true;

        public bool ModeBool
        {
            get { return this.modeBool; }
            set
            {
                if(this.modeBool != value)
                {
                    this.modeBool = value;
                    RaisePropertyChanged("ModeBool");
                    RaisePropertyChanged("Mode");
                    RaisePropertyChanged("ModeString");
                }
            }
        }
        #endregion

        #region Mode
        public ApplicationBarMode Mode
        {
            get { return ModeBool ? ApplicationBarMode.Default : ApplicationBarMode.Minimized; }
        }
        #endregion

        #region ModeString
        public string ModeString
        {
            get { return Mode.ToString(); }
        }
        #endregion

        #region ButtonIsEnabled
        private bool buttonIsEnabled;

        public bool ButtonIsEnabled
        {
            get { return this.buttonIsEnabled; }
            set
            {
                if(this.buttonIsEnabled != value)
                {
                    this.buttonIsEnabled = value;
                    RaisePropertyChanged("ButtonIsEnabled");
                }
            }
        }
        #endregion

        #region MenuItemIsEnabled
        private bool menuItemIsEnabled;

        public bool MenuItemIsEnabled
        {
            get { return this.menuItemIsEnabled; }
            set
            {
                if(this.menuItemIsEnabled != value)
                {
                    this.menuItemIsEnabled = value;
                    RaisePropertyChanged("MenuItemIsEnabled");
                }
            }
        }
        #endregion

        public ICommand TestCommand { get; private set; }

        #region TestCommandParameter
        private bool testCommandParameter;

        public bool TestCommandParameter
        {
            get { return this.testCommandParameter; }
            set
            {
                if(this.testCommandParameter != value)
                {
                    this.testCommandParameter = value;
                    RaisePropertyChanged("TestCommandParameter");
                }
            }
        }
        #endregion

        public ICommand TestCommand2 { get; private set; }

        #region TestCommand2Parameter
        private bool testCommand2Parameter;

        public bool TestCommand2Parameter
        {
            get { return this.testCommand2Parameter; }
            set
            {
                if(this.testCommand2Parameter != value)
                {
                    this.testCommand2Parameter = value;
                    RaisePropertyChanged("TestCommand2Parameter");
                }
            }
        }
        #endregion

        public ObservableCollection<MenuItemViewModel> MenuItems { get; private set; }
        public ObservableCollection<ButtonViewModel> Buttons { get; private set; }

        public PropertyBindingTestViewModel()
        {
            TestCommand = new DelegateCommand(
                p => MessageBox.Show("Tapped button when parameter checkbox was checked"),
                p => p is bool && (bool)p);
            TestCommand2 = new DelegateCommand(
                p => MessageBox.Show("Tapped menu item when parameter checkbox was checked"),
                p => p is bool && (bool)p);

            MenuItems = new ObservableCollection<MenuItemViewModel>();

            for (int i = 0; i < 45; i++)
            {
                AddMenuItemViewModel();
            }

            Buttons = new ObservableCollection<ButtonViewModel>();

            for (int i = 0; i < 2; i++)
            {
                AddButtonViewModel();
            }
        }

        private void AddMenuItemViewModel()
        {
            int j = MenuItems.Count;

            MenuItems.Add(
                new MenuItemViewModel
                {
                    Command = new DelegateCommand(
                        p =>
                        {
                            MessageBox.Show("MenuItem " + j);

                            for (int k = 0; k < MenuItems.Count; k++)
                            {
                                MenuItems[k].CommandParameter =
                                    (int)MenuItems[k].CommandParameter + 1;
                            }
                        },
                        p => (int)(p ?? 0) % 2 == 0),
                    CommandParameter = j,
                    Text = "MenuItem " + j
                });
            AddMenuItemCommand.RaiseCanExecuteChanged();
            AddNonBindableMenuItemCommand.RaiseCanExecuteChanged();
            RemoveMenuItemCommand.RaiseCanExecuteChanged();
            RemoveNonBindableMenuItemCommand.RaiseCanExecuteChanged();
        }

        private void AddButtonViewModel()
        {
            int j = Buttons.Count;

            Buttons.Add(
                new ButtonViewModel
                {
                    Command = new DelegateCommand(
                        p =>
                        {
                            MessageBox.Show("Button " + j);

                            for (int k = 0; k < Buttons.Count; k++)
                            {
                                Buttons[k].CommandParameter =
                                    (int)Buttons[k].CommandParameter + 1;
                            }
                        },
                        p => (int)(p ?? 0) % 2 == 0),
                    CommandParameter = j,
                    IconUri =
                        j % 2 == 0
                            ? new Uri("/Icons/Dark/appbar.back.rest.png", UriKind.Relative)
                            : new Uri("/Icons/Dark/appbar.next.rest.png", UriKind.Relative),
                    Text = "Button " + j
                });
            AddButtonCommand.RaiseCanExecuteChanged();
            AddNonBindableButtonCommand.RaiseCanExecuteChanged();
            RemoveButtonCommand.RaiseCanExecuteChanged();
            RemoveNonBindableButtonCommand.RaiseCanExecuteChanged();
        }

        #region AddButtonCommand
        private DelegateCommand addButtonCommand;
        public DelegateCommand AddButtonCommand
        {
            get
            {
                return addButtonCommand ?? (addButtonCommand = new DelegateCommand(AddButton, CanAddButton));
            }
        }

        private void AddButton(object parameter)
        {
            AddButtonViewModel();
        }

        private bool CanAddButton(object parameter)
        {
            return XamlDefinedButtonsCount + Buttons.Count + nonBindableButtons.Count < 4;
        }
        #endregion

        #region RemoveButtonCommand
        private DelegateCommand removeButtonCommand;
        public DelegateCommand RemoveButtonCommand
        {
            get
            {
                return removeButtonCommand ?? (removeButtonCommand = new DelegateCommand(RemoveButton, CanRemoveButton));
            }
        }

        private void RemoveButton(object parameter)
        {
            Buttons.RemoveAt(Buttons.Count - 1);
            AddButtonCommand.RaiseCanExecuteChanged();
            AddNonBindableButtonCommand.RaiseCanExecuteChanged();
            RemoveButtonCommand.RaiseCanExecuteChanged();
            RemoveNonBindableButtonCommand.RaiseCanExecuteChanged();
        }

        private bool CanRemoveButton(object parameter)
        {
            return Buttons.Count > 0;
        }
        #endregion

        #region AddNonBindableButtonCommand
        private DelegateCommand addNonBundableButtonCommand;
        public DelegateCommand AddNonBindableButtonCommand
        {
            get
            {
                return addNonBundableButtonCommand ?? (addNonBundableButtonCommand = new DelegateCommand(AddNonBindableButton, CanAddNonBindableButton));
            }
        }

        private bool CanAddNonBindableButton(object parameter)
        {
            return XamlDefinedButtonsCount + Buttons.Count + nonBindableButtons.Count < 4;
        }

        private void AddNonBindableButton(object parameter)
        {
            var page = (PhoneApplicationPage)parameter;
            var bar = page.ApplicationBar;
            var button = new ApplicationBarIconButton(
                new Uri("/Icons/Dark/appbar.add.rest.png", UriKind.RelativeOrAbsolute));
            button.Text = "NonBound " + nonBindableButtons.Count;
            nonBindableButtons.Add(button);
            bar.Buttons.Add(button);

            AddButtonCommand.RaiseCanExecuteChanged();
            AddNonBindableButtonCommand.RaiseCanExecuteChanged();
            RemoveButtonCommand.RaiseCanExecuteChanged();
            RemoveNonBindableButtonCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region RemoveNonBindableButtonCommand
        private DelegateCommand removeNonBindableButtonCommand;
        public DelegateCommand RemoveNonBindableButtonCommand
        {
            get
            {
                return removeNonBindableButtonCommand ?? (removeNonBindableButtonCommand = 
                    new DelegateCommand(RemoveNonBindableButton, CanRemoveNonBindableButton));
            }
        }

        private bool CanRemoveNonBindableButton(object parameter)
        {
            return nonBindableButtons.Count > 0;
        }

        private void RemoveNonBindableButton(object parameter)
        {
            var button = nonBindableButtons[nonBindableButtons.Count - 1];
            nonBindableButtons.Remove(button);
            var page = (PhoneApplicationPage)parameter;
            var bar = page.ApplicationBar;
            bar.Buttons.Remove(button);

            AddButtonCommand.RaiseCanExecuteChanged();
            AddNonBindableButtonCommand.RaiseCanExecuteChanged();
            RemoveButtonCommand.RaiseCanExecuteChanged();
            RemoveNonBindableButtonCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region AddMenuItemCommand
        private DelegateCommand addMenuItemCommand;
        public DelegateCommand AddMenuItemCommand
        {
            get
            {
                return addMenuItemCommand ?? (addMenuItemCommand = new DelegateCommand(AddMenuItem, CanAddMenuItem));
            }
        }

        private void AddMenuItem(object parameter)
        {
            AddMenuItemViewModel();
        }

        private bool CanAddMenuItem(object parameter)
        {
            return XamlDefinedMenuItemsCount + MenuItems.Count + nonBindableMenuItems.Count < 50;
        }
        #endregion

        #region RemoveMenuItemCommand
        private DelegateCommand removeMenuItemCommand;
        public DelegateCommand RemoveMenuItemCommand
        {
            get
            {
                return removeMenuItemCommand ?? (removeMenuItemCommand = new DelegateCommand(RemoveMenuItem, CanRemoveMenuItem));
            }
        }

        private void RemoveMenuItem(object parameter)
        {
            MenuItems.RemoveAt(MenuItems.Count - 1);
            AddMenuItemCommand.RaiseCanExecuteChanged();
            AddNonBindableMenuItemCommand.RaiseCanExecuteChanged();
            RemoveMenuItemCommand.RaiseCanExecuteChanged();
            RemoveNonBindableMenuItemCommand.RaiseCanExecuteChanged();
        }

        private bool CanRemoveMenuItem(object parameter)
        {
            return MenuItems.Count > 0;
        }
        #endregion

        #region AddNonBindableMenuItemCommand
        private DelegateCommand addNonBundableMenuItemCommand;
        public DelegateCommand AddNonBindableMenuItemCommand
        {
            get
            {
                return addNonBundableMenuItemCommand ?? (addNonBundableMenuItemCommand = new DelegateCommand(AddNonBindableMenuItem, CanAddNonBindableMenuItem));
            }
        }

        private bool CanAddNonBindableMenuItem(object parameter)
        {
            return XamlDefinedMenuItemsCount + MenuItems.Count + nonBindableMenuItems.Count < 50;
        }

        private void AddNonBindableMenuItem(object parameter)
        {
            var page = (PhoneApplicationPage)parameter;
            var bar = page.ApplicationBar;
            var menuItem = new ApplicationBarMenuItem { Text = "NonBound " + nonBindableMenuItems.Count };
            nonBindableMenuItems.Add(menuItem);
            bar.MenuItems.Add(menuItem);

            AddMenuItemCommand.RaiseCanExecuteChanged();
            AddNonBindableMenuItemCommand.RaiseCanExecuteChanged();
            RemoveMenuItemCommand.RaiseCanExecuteChanged();
            RemoveNonBindableMenuItemCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region RemoveNonBindableMenuItemCommand
        private DelegateCommand removeNonBindableMenuItemCommand;
        public DelegateCommand RemoveNonBindableMenuItemCommand
        {
            get
            {
                return removeNonBindableMenuItemCommand ?? (removeNonBindableMenuItemCommand =
                    new DelegateCommand(RemoveNonBindableMenuItem, CanRemoveNonBindableMenuItem));
            }
        }

        private bool CanRemoveNonBindableMenuItem(object parameter)
        {
            return nonBindableMenuItems.Count > 0;
        }

        private void RemoveNonBindableMenuItem(object parameter)
        {
            var menuItem = nonBindableMenuItems[nonBindableMenuItems.Count - 1];
            nonBindableMenuItems.Remove(menuItem);
            var page = (PhoneApplicationPage)parameter;
            var bar = page.ApplicationBar;
            bar.MenuItems.Remove(menuItem);

            AddMenuItemCommand.RaiseCanExecuteChanged();
            AddNonBindableMenuItemCommand.RaiseCanExecuteChanged();
            RemoveMenuItemCommand.RaiseCanExecuteChanged();
            RemoveNonBindableMenuItemCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}