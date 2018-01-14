namespace BudGet.Logic.Services
{
    public interface IAccountService
    {
        bool IsAuthenticated { get; set; }

        void ClearData();
    }
}
