using Xioa.Avalonia.Lib.Services;

namespace Ava.xUnit.Helpers;

public class PoetryStorageHelper {
    public static void RememberPoetryDbPathAsync() {
        System.IO.File.Delete(PoetryStorage.PoetryDbPath);
    }
}