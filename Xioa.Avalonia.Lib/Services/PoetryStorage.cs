using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;
using Xioa.Avalonia.Lib.Helpers;
using Xioa.Avalonia.Lib.Models;

namespace Xioa.Avalonia.Lib.Services;

public class PoetryStorage : IPoetryStorage {
    public bool IsInitialized { get; }
    public const int NumberPoetry = 30;
    public const string DbName = "poetrydb.sqlite3";

    public static readonly string PoetryDbPath =
        PathHelper.GetLocalFilePath(DbName);

    private SQLiteAsyncConnection? _sqLiteAsyncConnection;

    private SQLiteAsyncConnection SqLiteAsyncConnection
        => _sqLiteAsyncConnection ??= new SQLiteAsyncConnection(PoetryDbPath);

    public async Task InitializeAsync() {
        await using FileStream dbFileStream = new FileStream(PoetryDbPath, FileMode.OpenOrCreate);
        await using var dbAssetStream = typeof(PoetryStorage).Assembly.GetManifestResourceStream(
            DbName);
        if (dbAssetStream is not null)
            await dbAssetStream.CopyToAsync(dbFileStream);
        //throw new MissingManifestResourceException();
    }

    public Task<Poetry> GetPoetryAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<IList<Poetry>> GetPoetriesAsync(Expression<Func<Poetry, bool>> where, int skip, int take) {
        throw new NotImplementedException();
    }
}