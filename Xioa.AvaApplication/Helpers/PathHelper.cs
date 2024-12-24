using System;

namespace Xioa.AvaApplication.Helpers;

/// <summary>
/// @author Xioa
/// @date  2024年12月24日
/// </summary>
public static class PathHelper
{
    private static string _localFolder = string.Empty;

    private static string LocalFolder
    {
        get
        {
            if (!string.IsNullOrEmpty(_localFolder))
            {
                return _localFolder;
            }

            _localFolder =
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    nameof(AvaApplication));
            if (!System.IO.Directory.Exists(_localFolder))
            {
                System.IO.Directory.CreateDirectory(_localFolder);
            }

            return _localFolder;
        }
    }

    public static string GetLocalFilePath(string fileName)
    {
        return System.IO.Path.Combine(LocalFolder, fileName);
    }
}