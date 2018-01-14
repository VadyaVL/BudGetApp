using BudGet.Logic.Services;
using MvvmCross.Platform;

namespace BudGet.Logic
{
    public static class MvvmConfiguration
    {
        public static void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<IAccountService, AccountService>();
        }
    }
}
