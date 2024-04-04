using GYMGO.Desktop.ViewModels;
using GYMGO.Desktop.ViewModels.ControlPanel;
using GYMGO.Desktop.ViewModels.Gympass;
using GYMGO.Desktop.ViewModels.Login;
using GYMGO.Desktop.ViewModels.Users;
using GYMGO.Desktop.ViewModels.Supplements;
using GYMGO.Desktop.Views;
using GYMGO.Desktop.Views.ControlPanel;
using GYMGO.Desktop.Views.Login;
using GYMGO.Desktop.Views.Users;
using GYMGO.Desktop.Views.Supplements;
using Microsoft.Extensions.DependencyInjection;
using GYMGO.Desktop.Views.Gympass;

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

            services.AddSingleton<GympassViewModel>();
            services.AddSingleton<GympassView>(s => new GympassView()
            {
                DataContext = s.GetRequiredService<GympassViewModel>()
            });

            services.AddSingleton<PassesViewModel>();
            services.AddSingleton<Passes>(s => new Passes()
            {
                DataContext = s.GetRequiredService<PassesViewModel>()
            });

            services.AddSingleton<TicketsViewModel>();
            services.AddSingleton<Tickets>(s => new Tickets()
            {
                DataContext = s.GetRequiredService<TicketsViewModel>()
            });

            services.AddSingleton<SupplementsViewModel>();
            services.AddSingleton<SupplementsView>(s => new SupplementsView()
            {
                DataContext = s.GetRequiredService<SupplementsViewModel>()
            });

            services.AddSingleton<NutrionalViewModel>();
            services.AddSingleton<NutrionalView>(s => new NutrionalView()
            {
                DataContext = s.GetRequiredService<NutrionalViewModel>()
            });

            services.AddSingleton<EquipmentViewModel>();
            services.AddSingleton<EquipmentView>(s => new EquipmentView()
            {
                DataContext = s.GetRequiredService<EquipmentViewModel>()
            });
        }
    }
}
