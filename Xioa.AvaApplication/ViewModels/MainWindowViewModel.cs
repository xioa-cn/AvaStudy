using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Xioa.AvaApplication.Models;
using Xioa.AvaApplication.Services;

namespace Xioa.AvaApplication.ViewModels;

public partial class MainWindowViewModel(IModelStorage modelStorage) : ViewModelBase {
    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private async Task InitializeAsync() {
        await modelStorage.InitializeAsync();
    }

    [RelayCommand]
    private async Task InsertAsync() {
        await modelStorage.InsertAsync(new ApplicationConfig
        {
            Name = "Key"
        });
    }
}