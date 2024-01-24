using MAUIAppearingEventAndFlexLayoutBugs.Pages;

namespace MAUIAppearingEventAndFlexLayoutBugs
{
    public partial class App : Application
    {
        public static FlyoutPage AppearingEventBugRootFlyoutPage;
        public App()
        {
            InitializeComponent();

            // Change the MainPae to change each bug 

            MainPage = new NavigationPage(new FlexLayoutBugPage());
            //MainPage = new AppearingEventBugRootFlyoutPage();

        }
    }
}
