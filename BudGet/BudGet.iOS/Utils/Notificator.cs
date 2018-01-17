using BigTed;
using BudGet.iOS.Utils;
using BudGet.Utils;
using Xamarin.Forms;

[assembly: Dependency(typeof(Notificator))]
namespace BudGet.iOS.Utils
{
    public class Notificator : INotificator
    {
        public override void ShowError(string message)
        {
            BTProgressHUD.ShowErrorWithStatus(message, DisplayTime * 1000);     // sec * ms
        }

        public override void ShowSuccessfull(string message)
        {
            BTProgressHUD.ShowSuccessWithStatus(message, DisplayTime * 1000);   // sec * ms
        }
    }
}