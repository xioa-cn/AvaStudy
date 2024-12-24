using System;
using Microsoft.Extensions.DependencyInjection;
using Xioa.AvaApplication.Services;
using Xioa.AvaApplication.ViewModels;

namespace Xioa.AvaApplication;

public class ServiceLocator {
    public readonly IServiceProvider ServiceProvider;

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IModelStorage, ModelStorage>();
        serviceCollection.AddSingleton<MainWindowViewModel>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public MainWindowViewModel MainWindowViewModel 
        => this.ServiceProvider.GetService<MainWindowViewModel>();
}