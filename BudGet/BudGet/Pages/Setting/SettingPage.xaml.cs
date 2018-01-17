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

        private ObservableCollection<SettingVm> collection = new ObservableCollection<SettingVm>();

        public ObservableCollection<SettingVm> Collection { get => this.collection; }

        #endregion

        #region Construcors

        public SettingPage ()
		{
			InitializeComponent ();

            this.Collection.Add(
                new SettingVm
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
            if (sender is ListView listView && e.SelectedItem is SettingVm item && item != null)
            {
                listView.SelectedItem = null;
                await Navigation.PushAsync(Activator.CreateInstance(item.TargetType) as Page);
            }
        }

        #endregion
    }
}