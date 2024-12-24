using System;
using System.Collections.Generic;
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

    public Task InitializeAsync() {
        throw new NotImplementedException();
    }

    public Task<Poetry> GetPoetryAsync(int id) {
        throw new NotImplementedException();
    }

    public Task<IList<Poetry>> GetPoetriesAsync(Expression<Func<Poetry, bool>> where, int skip, int take) {
        throw new NotImplementedException();
    }
}