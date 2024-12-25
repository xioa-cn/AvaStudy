using Moq;
using Xioa.Avalonia.Lib.Services;

namespace Ava.xUnit.Services;

public class PoetryStorageIsInitializedTest {
    [Fact]
    public void IsInitialized_Success() {
        var preferenceStorageMock = new Mock<IPreferenceStorage>();

        preferenceStorageMock.Setup(p =>
                p.Get(PoetryStorageConstant.VersionKey, default(int)))
            .Returns(PoetryStorageConstant.Version);

        var mock = preferenceStorageMock.Object;
        var poetryStorage = new PoetryStorage(mock);

        Assert.True(poetryStorage.IsInitialized);
        preferenceStorageMock.Verify(p =>
            p.Get(PoetryStorageConstant.VersionKey, default(int)), Times.Once);
    }
}