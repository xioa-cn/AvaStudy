using Ava.xUnit.Helpers;

namespace Ava.xUnit.Services;

public class PoetryStorageGetPoetryAsyncTest : IDisposable {
    [Fact]
    public async Task GetPoetryAsync_Success() {
        var poetryStorage = await PoetryStorageHelper.GetInitializedPoetryStorage();
        var poetry = await poetryStorage.GetPoetryAsync(10001);
        Assert.NotNull(poetry);
        await poetryStorage.Close();
    }

    public void Dispose() {
        PoetryStorageHelper.RememberPoetryDbPathAsync();
    }
}