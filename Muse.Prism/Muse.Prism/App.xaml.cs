using Muse.Prism.ViewModels;
using Muse.Prism.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Muse.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/IncidentsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPage, CreateAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<LocationPage, LocationPageViewModel>();
            containerRegistry.RegisterForNavigation<CodePage, CodePageViewModel>();
            containerRegistry.RegisterForNavigation<MonitorPage, MonitorPageViewModel>();
            containerRegistry.RegisterForNavigation<AddEditMonitor, AddEditMonitorViewModel>();
            containerRegistry.RegisterForNavigation<MonitoreadasPage, MonitoreadasPageViewModel>();
            containerRegistry.RegisterForNavigation<IncidentsPage, IncidentsPageViewModel>();
            containerRegistry.RegisterForNavigation<AddIncidentPage, AddIncidentPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateIncidentPage, CreateIncidentPageViewModel>();
            containerRegistry.RegisterForNavigation<AccompanimentPage, AccompanimentPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RecoveryAccountPage, RecoveryAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<ResetPasswordPage, ResetPasswordPageViewModel>();
        }
    }
}
