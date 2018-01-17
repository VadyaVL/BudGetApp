using System.ComponentModel;

namespace BudGet.ViewModels
{
    public class EditPasswordVm: INotifyPropertyChanged
    {
        public bool IsCurrentPasswordSet { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public EditPasswordVm()
        {
            this.CurrentPassword = string.Empty;
            this.NewPassword = string.Empty;
            this.ConfirmPassword = string.Empty;
        }

        public bool Validate()
        {
            // We don't check CurrentPassword, because it may be empty.
            // Check it in page class.
            return !string.IsNullOrWhiteSpace(this.NewPassword) &&
                   !string.IsNullOrWhiteSpace(this.ConfirmPassword) &&
                   //this.NewPassword.Equals(this.ConfirmPassword);
                    this.NewPassword.Length == this.ConfirmPassword.Length;
        }

        public void Clear()
        {
            this.CurrentPassword = string.Empty;
            this.NewPassword = string.Empty;
            this.ConfirmPassword = string.Empty;

            // Change by one
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(this.CurrentPassword));
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(this.NewPassword));
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(this.ConfirmPassword));
            }
        }
    }
}