using System;
using System.Resources;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Xioa.AvaApplication.Services;
using Xioa.AvaApplication.ViewModels;
using Xioa.Avalonia.Lib.Services;
using Xioa.Avalonia.Lib.ViewModels;

namespace Xioa.AvaApplication;

public class ServiceLocator {
    private readonly IServiceProvider _serviceProvider;

    private static ServiceLocator? _current;

    public static ServiceLocator Current {
        get
        {
            if (_current != null)
            {
                return _current;
            }

            if (Application.Current == null
                || !Application.Current.TryGetResource(
                    nameof(ServiceLocator), null, out var instance
                )
                || instance is not ServiceLocator serviceLocator) throw new MissingManifestResourceException();
            _current = serviceLocator;
            return serviceLocator;
        }
    }

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IPoetryStorage, PoetryStorage>();
        serviceCollection.AddSingleton<IPreferenceStorage, FilePreferenceStorage>();
        serviceCollection.AddSingleton<ResultViewModel>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public MainWindowViewModel? MainWindowViewModel
        => this._serviceProvider.GetService<MainWindowViewModel>();


    public ResultViewModel? ResultViewModel
        => this._serviceProvider.GetService<ResultViewModel>();
}