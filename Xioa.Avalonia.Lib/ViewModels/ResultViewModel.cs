using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AvaloniaInfiniteScrolling;
using CommunityToolkit.Mvvm.Input;
using Xioa.Avalonia.Lib.Models;
using Xioa.Avalonia.Lib.Services;

namespace Xioa.Avalonia.Lib.ViewModels;

public partial class ResultViewModel : ViewModelBase {
    private IPoetryStorage _poetryStorage;
    private const int PageSize = 5;

    public ResultViewModel(IPoetryStorage poetryStorage) {
        _poetryStorage = poetryStorage;
        if (!_poetryStorage.IsInitialized)
        {
            _poetryStorage.InitializeAsync();
        }

        PoetryInfiniteScrollCollection = new AvaloniaInfiniteScrollCollection<Poetry>();
        PoetryInfiniteScrollCollection.OnLoadMore = async () =>
        {
            return await _poetryStorage.GetPoetriesAsync(
                e => e.Id > 0, PoetryInfiniteScrollCollection.Count, PageSize
            );
        };
        PoetryInfiniteScrollCollection.OnCanLoadMore = () => { return PoetryInfiniteScrollCollection.Count < 30; };
    }

    public ObservableCollection<Poetry> PoetryCollection { get; } = new ObservableCollection<Poetry>();


    [RelayCommand]
    private async Task OnInitializeAsync() {
        var poetries = await _poetryStorage.GetPoetriesAsync(
            e => e.Id > 0, 0, int.MaxValue
        );
        foreach (var item in poetries)
        {
            PoetryCollection.Add(item);
        }
    }

    public AvaloniaInfiniteScrollCollection<Poetry> PoetryInfiniteScrollCollection { get; }
}