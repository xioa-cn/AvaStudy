using Ava.xUnit.Helpers;

namespace Ava.xUnit.Services;

public class PoetryStorageGetPoetriesAsyncTest : IDisposable {
    [Fact]
    public async Task GetPoetriesAsync_Success() {
        var poetryStorage = await PoetryStorageHelper.GetInitializedPoetryStorage();
        var poetries = await poetryStorage.GetPoetriesAsync(
            e => e.Id > 0, 0, int.MaxValue
        );
        Assert.NotNull(poetries);
        await poetryStorage.Close();
    }

    public void Dispose() {
        PoetryStorageHelper.RememberPoetryDbPathAsync();
    }
}