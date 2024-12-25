using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;
using Xioa.Avalonia.Lib.Helpers;
using Xioa.Avalonia.Lib.Models;

namespace Xioa.Avalonia.Lib.Services;

public static class PoetryStorageConstant {
    public const string VersionKey = nameof(PoetryStorageConstant) + "." + nameof(Version);
    public const int Version = 1;
}

public class PoetryStorage : IPoetryStorage {
    public PoetryStorage(IPreferenceStorage preferenceStorage) {
        _preferenceStorage = preferenceStorage;
    }

    public bool IsInitialized =>
        _preferenceStorage.Get(PoetryStorageConstant.VersionKey, default(int)) == PoetryStorageConstant.Version;

    public const int NumberPoetry = 30;
    public const string DbName = "poetrydb.sqlite3";

    public static readonly string PoetryDbPath =
        PathHelper.GetLocalFilePath(DbName);

    private SQLiteAsyncConnection? _sqLiteAsyncConnection;
    private readonly IPreferenceStorage _preferenceStorage;


    private SQLiteAsyncConnection SqLiteAsyncConnection
        => _sqLiteAsyncConnection ??= new SQLiteAsyncConnection(PoetryDbPath);

    public async Task InitializeAsync() {
        await using var dbFileStream = new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
        await using var dbAssetStream = typeof(PoetryStorage).Assembly.GetManifestResourceStream(
            DbName);
        if (dbAssetStream is not null)
            await dbAssetStream.CopyToAsync(dbFileStream);
        _preferenceStorage.Set(PoetryStorageConstant.VersionKey, PoetryStorageConstant.Version);
    }

    public async Task<Poetry> GetPoetryAsync(int id) =>
        await SqLiteAsyncConnection.Table<Poetry>().FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IList<Poetry>> GetPoetriesAsync(Expression<Func<Poetry, bool>> where, int skip, int take)
        => await SqLiteAsyncConnection.Table<Poetry>().Where(where).Skip(skip).Take(take).ToListAsync();

    public async Task Close() {
        await SqLiteAsyncConnection.CloseAsync();
    }
}