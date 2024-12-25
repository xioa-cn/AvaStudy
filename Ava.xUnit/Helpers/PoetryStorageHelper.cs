using Moq;
using Xioa.Avalonia.Lib.Services;

namespace Ava.xUnit.Helpers;

public class PoetryStorageHelper {
    public static void RememberPoetryDbPathAsync() {
        System.IO.File.Delete(PoetryStorage.PoetryDbPath);
    }

    public static void RememberVersionKeyAsync() {
        System.IO.File.Delete(PoetryStorage.PoetryDbPath);
    }

    public static async Task<PoetryStorage> GetInitializedPoetryStorage() {
        var preferenceStorageMock = new Mock<IPreferenceStorage>();
        preferenceStorageMock.Setup(
                p => p.Get(PoetryStorageConstant.VersionKey, -1))
            .Returns(-1)
            ;
        var preferenceStorage = preferenceStorageMock.Object;
        var poetryStorage = new PoetryStorage(preferenceStorage);
        await poetryStorage.InitializeAsync();
        return poetryStorage;
    }
}