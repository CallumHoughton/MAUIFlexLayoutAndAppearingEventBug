using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIAppearingEventAndFlexLayoutBugs.ViewModels
{
    public class AppearingEventBugChildPageViewModel : BaseViewModel
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigateBackAsync();
        }

        private async Task NavigateBackAsync()
        {
            await Task.Delay(3000);
            await App.AppearingEventBugRootFlyoutPage.Detail.Navigation.PopAsync();
        }
    }
}
