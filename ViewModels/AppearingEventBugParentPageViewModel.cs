using MAUIAppearingEventAndFlexLayoutBugs.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIAppearingEventAndFlexLayoutBugs.ViewModels
{
    public class AppearingEventBugParentPageViewModel : BaseViewModel
    {

        private bool _isNavigating = false;
        public bool IsNavigating
        {
            get => _isNavigating;
            set
            {
                _isNavigating = value;
                OnPropertyChanged(nameof(IsNavigating));
            }
        }

        private int _appearingEventCounter = 0;
        public int AppearingEventCounter
        {
            get => _appearingEventCounter;
            set
            {
                _appearingEventCounter = value;
                OnPropertyChanged(nameof(AppearingEventCounter));
            }
        }

        public ICommand ToggleNavigationProcessCommand { get ; private set; }

        public AppearingEventBugParentPageViewModel()
        {
            ToggleNavigationProcessCommand = new Command(() =>
            {
                ToggleNavigationProcess();
            });
        }

        public void ToggleNavigationProcess()
        {
            IsNavigating = !IsNavigating;
            if (IsNavigating)
            {
                AppearingEventCounter = 0;
                App.AppearingEventBugRootFlyoutPage.Detail.Navigation.PushAsync(new AppearingEventBugChildPage());
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            AppearingEventCounter++;
            if (IsNavigating)
            {
                // if you uncomment out the delay, the pages then begin auto navigating in a cycle correctly
                // otherwise the events seem to misfire and navigation stops
                //await Task.Delay(500);
                await App.AppearingEventBugRootFlyoutPage.Detail.Navigation.PushAsync(new AppearingEventBugChildPage());
            }
        }
    }
}
