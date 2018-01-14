using BudGet.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace BudGet.Pages
{
	public partial class MainPage : MasterDetailPage, INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<MenuVm> collectionMenu = new ObservableCollection<MenuVm>();

        public ObservableCollection<MenuVm> CollectionMenu { get => this.collectionMenu; }

        private MenuVm selected;

        public MenuVm Selected
        {
            get => this.selected;
            set
            {
                this.selected = value;
                this.OnPropertyChanged(nameof(this.Selected));
            }
        }

        #endregion

        public MainPage()
		{
			InitializeComponent();

            this.CreateHamburgerMenu();
        }

        #region Methods

        private void CreateHamburgerMenu()
        {
            var pageWelcome = new MenuVm() { Title = "Welcome", Icon = ImageSource.FromResource("BudGet.Images.Menu.Welcome.png"), TargetType = typeof(WelcomePage) };

            this.CollectionMenu.Add(pageWelcome);

            this.Selected = pageWelcome;

            this.Detail = new NavigationPage((Page)Activator.CreateInstance(this.Selected.TargetType));
        }

        #endregion

        #region Events

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if(sender is ListView listView && e.SelectedItem is MenuVm menu)
            {
                if(menu.TargetType != null)
                {
                    this.Detail = new NavigationPage((Page)Activator.CreateInstance(menu.TargetType));
                    this.IsPresented = false;
                }

                listView.SelectedItem = null;
            }
        }

        #endregion
    }
}
