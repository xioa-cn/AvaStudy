using Ava.xUnit.Helpers;
using Xioa.Avalonia.Lib.Services;

namespace Ava.xUnit.Services;

public class FilePreferenceStorageTest : IDisposable {
    [Fact]
    public void GetSet_Success() {
        FilePreferenceStorage preferenceStorage = new FilePreferenceStorage();
        preferenceStorage.Set(PoetryStorageConstant.VersionKey, 1);

        Assert.True(preferenceStorage.Get(PoetryStorageConstant.VersionKey, default(int)) ==
                    PoetryStorageConstant.Version);
    }

    public void Dispose() {
        PoetryStorageHelper.RememberVersionKeyAsync();
    }
}