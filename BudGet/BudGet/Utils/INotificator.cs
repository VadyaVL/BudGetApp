namespace BudGet.Utils
{
    public abstract class INotificator
    {
        protected static int DisplayTime = 3;   // in sec

        public abstract void ShowError(string message);

        public abstract void ShowSuccessfull(string message);
    }
}