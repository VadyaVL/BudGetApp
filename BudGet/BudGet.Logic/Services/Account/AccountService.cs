using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BudGet.Logic.Services
{
    public class AccountService : IAccountService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public bool IsAuthenticated
        {
            get => AppSettings.GetValueOrDefault(nameof(this.IsAuthenticated), false);
            set => AppSettings.AddOrUpdateValue(nameof(this.IsAuthenticated), value);
        }

        public string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(this.Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(this.Password), value);
        }

        public void ClearData()
        {
            AppSettings.Remove(nameof(this.IsAuthenticated));
        }
    }
}
