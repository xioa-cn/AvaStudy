using Ava.xUnit.Helpers;
using Moq;
using Xioa.Avalonia.Lib.Services;

namespace Ava.xUnit.Services;

public class PoetryStorageInitializeTest : IDisposable {
    [Fact]
    public async Task InitializeAsync_Success() {
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        var mock = preferenceStorageMock.Object;
        var poetryStorage = new PoetryStorage(mock);
        Assert.False(File.Exists(PoetryStorage.PoetryDbPath));
        await poetryStorage.InitializeAsync();
        Assert.True(File.Exists(PoetryStorage.PoetryDbPath));
    }

    public void Dispose() {
        PoetryStorageHelper.RememberPoetryDbPathAsync();
    }
}