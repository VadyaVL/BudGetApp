namespace BudGet.ViewModels
{
    public class LoginVm
    {
        public string Password { get; set; }

        public LoginVm()
        {
            this.Password = string.Empty;
        }
    }
}