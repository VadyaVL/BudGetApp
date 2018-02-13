using BudGet.Dal;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BudGet.Logic.Services
{
    public class AccountService : BasicService, IAccountService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public AccountService(IUow unit) : base(unit)
        {

        }

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
