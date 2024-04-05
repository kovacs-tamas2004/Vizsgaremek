using GYMGO.Desktop.ViewModels;
using GYMGO.Desktop.ViewModels.ControlPanel;
using GYMGO.Desktop.ViewModels.Login;
using GYMGO.Desktop.ViewModels.Users;
using GYMGO.Desktop.Views;
using GYMGO.Desktop.Views.ControlPanel;
using GYMGO.Desktop.Views.Login;
using GYMGO.Desktop.Views.Users;
using Microsoft.Extensions.DependencyInjection;

namespace GYMGO.Desktop.Extensions
{
    public static class ViewViewModelsExtensions
    {
        public static void ConfigureViewViewModels(this IServiceCollection services)
        {
            // MainView
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            // LoginView
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(s => new LoginView()
            {
                DataContext = s.GetRequiredService<LoginViewModel>()
            });

            // ControlPanel
            services.AddSingleton<ControlPanelViewModel>();
            services.AddSingleton<ControlPanelView>(s => new ControlPanelView()
            {
                DataContext = s.GetRequiredService<ControlPanelViewModel>()
            });
            // School Citizens
            services.AddSingleton<UsersViewModel>();
            services.AddSingleton<UsersView>(s => new UsersView()
            {
                DataContext = s.GetRequiredService<UsersViewModel>()
            });

            // Students
            // School Citizens
            services.AddSingleton<VisitorsViewModel>();
            services.AddSingleton<VisitorsView>(s => new VisitorsView()
            {
                DataContext = s.GetRequiredService<VisitorsViewModel>()
            });

            services.AddSingleton<TrainersViewModel>();
            services.AddSingleton<Trainers>(s => new Trainers()
            {
                DataContext = s.GetRequiredService<TrainersViewModel>()
            });

            services.AddSingleton<OwnersViewModel>();
            services.AddSingleton<Owners>(s => new Owners()
            {
                DataContext = s.GetRequiredService<OwnersViewModel>()
            });
        }
    }
}
