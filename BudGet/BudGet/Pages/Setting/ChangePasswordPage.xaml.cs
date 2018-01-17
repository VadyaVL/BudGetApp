using BudGet.CustomControls;
using BudGet.Logic.Services;
using BudGet.Utils;
using BudGet.ViewModels;
using MvvmCross.Platform;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudGet.Pages
{
    // Add ability to remove current password
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePasswordPage : ContentPage
	{
        #region Props

        private IAccountService AccountService { get; set; }

        private EditPasswordVm editPassword;

        #endregion

        #region Components

        private DynamicToolbarItem toolBarItemSave;

        #endregion

        #region Constructors

        public ChangePasswordPage ()
		{
			InitializeComponent ();
            this.InitToolBar();

            this.AccountService = Mvx.Resolve<IAccountService>();

            this.editPassword = new EditPasswordVm
            {
                IsCurrentPasswordSet = !string.IsNullOrEmpty(this.AccountService.Password)
            };
            this.BindingContext = this.editPassword;
        }

        private void InitToolBar()
        {
            this.toolBarItemSave = new DynamicToolbarItem
            {
                Text = Resource.TextSave,
                Icon = "action_save_white_margin.png",
                IconTransparent = "action_save_transparent_margin.png",
                IsEnable = false,
            };
            this.toolBarItemSave.Clicked += ClickSave;

            this.ToolbarItems.Add(toolBarItemSave);
        }

        #endregion

        #region Methods
        
        #endregion

        #region Events

        // Set it to every entry
        private void EntryPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (this.toolBarItemSave != null && args.PropertyName.Equals("Text"))
            {
                this.toolBarItemSave.IsEnable = this.editPassword.Validate() &&
                    (string.IsNullOrWhiteSpace(this.AccountService.Password) || 
                    !string.IsNullOrWhiteSpace(this.editPassword.CurrentPassword));
            }
        }

        private void ClickSave(object sender, EventArgs args)
        {
            if (this.editPassword.CurrentPassword.Equals(this.AccountService.Password) &&
                this.editPassword.NewPassword.Equals(this.editPassword.ConfirmPassword))
            {
                this.AccountService.Password = this.editPassword.NewPassword;
                this.editPassword.Clear();
                Displayer.Instance.ShowSuccessfull(Resource.TextChangePasswordSuccessfull);
            }
            else
            {
                Displayer.Instance.ShowError(Resource.TextChangePasswordError);
            }

            //////Popup.Instance.DisplaySpinnerSpinner(true);
            //var respone = await RestSettingsService.ChangePassword(entryCurrentPasword.Text, entryNewPassword.Text, entryConfirmNewPassword.Text);

            //if (respone.IsError)
            //{
            //    //Popup.Instance.DisplaySpinnerError(respone.ErrorMessage);
            //}
            //else
            //{
            //    if (respone.Data.HasValue && respone.Data.Value)
            //    {
            //        //Popup.Instance.DisplaySpinnerSuccessful(Resource.MessagePasswordUpdated);
            //        this.toolBarItemSave.IsEnable = false;

            //        entryCurrentPasword.Text = string.Empty;
            //        entryNewPassword.Text = string.Empty;
            //        entryConfirmNewPassword.Text = string.Empty;
            //    }
            //    else
            //    {
            //        //Popup.Instance.DisplaySpinnerError(Resource.MessagePasswordNotUpdated);
            //    }
            //}
            //////Popup.Instance.DisplaySpinnerSpinner(false);
        }

        #endregion
    }
}