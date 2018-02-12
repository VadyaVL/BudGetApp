using BudGet.Logic.Services;
using FreshTinyIoC;

namespace BudGet.Logic
{
    public static class IoCConfiguration
    {
        public static void RegisterDependencies(FreshTinyIoCContainer container)
        {
            container.Register<IAccountService, AccountService>();
        }
    }
}