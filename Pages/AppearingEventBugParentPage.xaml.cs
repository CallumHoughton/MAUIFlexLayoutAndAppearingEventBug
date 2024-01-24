using MAUIAppearingEventAndFlexLayoutBugs.ViewModels;

namespace MAUIAppearingEventAndFlexLayoutBugs.Pages;

public partial class AppearingEventBugParentPage : ContentPage
{
    private AppearingEventBugParentPageViewModel _vm;

    public AppearingEventBugParentPage()
    {
        InitializeComponent();
        BindingContext = _vm = new AppearingEventBugParentPageViewModel();

        Appearing += (sender, e) =>
        {
            _vm.SecureOnAppearing();
        };
    }
}