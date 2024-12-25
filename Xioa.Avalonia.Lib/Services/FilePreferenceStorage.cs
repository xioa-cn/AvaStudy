using System;
using System.Globalization;
using System.IO;
using Xioa.Avalonia.Lib.Helpers;

namespace Xioa.Avalonia.Lib.Services;

public class FilePreferenceStorage : IPreferenceStorage {
    public void Set(string key, int value) =>
        Set(key, value.ToString());

    public int Get(string key, int defaultValue) =>
        int.TryParse(Get(key, string.Empty), out var result) ? result : defaultValue;

    public void Set(string key, string value) {
        var path = PathHelper.GetLocalFilePath(key);
        File.WriteAllText(path, value);
    }

    public string Get(string key, string defaultValue) {
        var path = PathHelper.GetLocalFilePath(key);
        return File.Exists(path) ? File.ReadAllText(path) : defaultValue;
    }

    public void Set(string key, DateTime value) => Set(key, value.ToString(CultureInfo.InvariantCulture));

    public DateTime Get(string key, DateTime defaultValue) =>
        DateTime.TryParse(Get(key, string.Empty), DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out var result)
            ? result
            : defaultValue;
}