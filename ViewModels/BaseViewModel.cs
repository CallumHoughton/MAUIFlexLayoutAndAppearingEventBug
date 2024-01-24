using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MAUIAppearingEventAndFlexLayoutBugs.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _canExecute = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanExecute
        {
            get
            {
                return _canExecute;
            }

            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    OnPropertyChanged("CanExecute");
                }
            }
        }

        public void SecureOnAppearing()
        {
            try
            {
                OnAppearing();
            }
            catch (Exception e)
            {
                ErrorOccured(e);
            }
        }

        public void SecureOnDisappearing()
        {
            try
            {
                OnDisappearing();
            }
            catch (Exception e)
            {
                ErrorOccured(e);
            }
        }


        public BaseViewModel()
        {
        }

        /// <summary>  Runs a task, and disables execution of command argument until completion</summary>
        /// <param name="task">The task.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task RunDisableDoubleClickTask(Task task, ICommand command)
        {
            CanExecute = false;
            ((Command)command).ChangeCanExecute();

            await task;

            CanExecute = true;
            ((Command)command).ChangeCanExecute();
        }

        protected virtual void OnAppearing() // can be used to launch 'OnAppearing' methods in ViewModel
        {

        }

        protected virtual void OnDisappearing() // can be used to launch 'OnDisappearing' methods in ViewModel
        {

        }

        protected virtual void ErrorOccured(Exception e)
        {
            Debug.WriteLine(e);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
