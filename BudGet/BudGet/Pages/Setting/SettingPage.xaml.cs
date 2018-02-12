using BudGet.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
        #region Props

        private ObservableCollection<MenuViewModel> collection = new ObservableCollection<MenuViewModel>();

        public ObservableCollection<MenuViewModel> Collection { get => this.collection; }

        #endregion

        #region Construcors

        public SettingPage ()
		{
			InitializeComponent ();

            this.Collection.Add(
                new MenuViewModel
                {
                    Icon = ImageSource.FromResource("BudGet.Images.Lock.png"),
                    Title = Resource.TextChangePassword,
                    TargetType = typeof(ChangePasswordPage)
                });
        }

        #endregion

        #region Events

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender is ListView listView && e.SelectedItem is MenuViewModel item && item != null)
            {
                listView.SelectedItem = null;
                await Navigation.PushAsync(Activator.CreateInstance(item.TargetType) as Page);
            }
        }

        #endregion
    }
}