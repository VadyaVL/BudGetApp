using Android.App;
using Android.OS;

namespace BudGet.Droid
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.StartActivity(typeof(MainActivity));
        }
    }
}