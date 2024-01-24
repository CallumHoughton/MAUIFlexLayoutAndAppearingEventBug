using MAUIAppearingEventAndFlexLayoutBugs.ViewModels;

namespace MAUIAppearingEventAndFlexLayoutBugs.Pages;

public partial class AppearingEventBugChildPage : ContentPage
{
    private readonly AppearingEventBugChildPageViewModel _vm;
    public AppearingEventBugChildPage()
    {
        InitializeComponent();

        BindingContext = _vm = new AppearingEventBugChildPageViewModel();

        Appearing += (sender, e) =>
        {
            // this seems to fire twice? To maybe this is what is causing the parent Appearing event to fire twice also
            _vm.SecureOnAppearing();
        };
    }
}