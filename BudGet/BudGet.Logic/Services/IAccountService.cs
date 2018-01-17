namespace BudGet.Logic.Services
{
    public interface IAccountService
    {
        bool IsAuthenticated { get; set; }

        string Password { get; set; }

        void ClearData();
    }
}
