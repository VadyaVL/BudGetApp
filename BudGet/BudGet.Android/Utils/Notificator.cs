using System;
using Android.App;
using AndroidHUD;
using BudGet.Droid.Utils;
using BudGet.Utils;
using Xamarin.Forms;

[assembly: Dependency(typeof(Notificator))]
namespace BudGet.Droid.Utils
{
    public class Notificator : INotificator
    {
        // Find way to fix obsolete. Android.App.Application.Context - throw exception
#pragma warning disable CS0618 // 'Forms.Context' is obsolete: 'Context is obsolete as of version 2.5. Please use a local context instead.'
        private Activity CurrentActivity { get => Forms.Context as Activity; }
#pragma warning restore CS0618 // 'Forms.Context' is obsolete: 'Context is obsolete as of version 2.5. Please use a local context instead.'

        public override void ShowError(string message)
        {
            AndHUD.Shared.ShowError(this.CurrentActivity, message, MaskType.None, TimeSpan.FromSeconds(DisplayTime));
        }

        public override void ShowSuccessfull(string message)
        {
            AndHUD.Shared.ShowSuccess(this.CurrentActivity, message, MaskType.None, TimeSpan.FromSeconds(DisplayTime));
        }
    }
}