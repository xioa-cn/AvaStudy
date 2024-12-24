using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xioa.AvaApplication.Models;

namespace Xioa.AvaApplication.Services;

public class ModelStorage : IModelStorage {
    public const string DbName = "XioaApplication.sqlite3";

    public static readonly string ModelDbPath = Helpers.PathHelper.GetLocalFilePath(DbName);

    private SQLiteAsyncConnection? _sqLiteAsyncConnection;

    private SQLiteAsyncConnection SqLiteAsyncConnection
        => _sqLiteAsyncConnection ??= new SQLiteAsyncConnection(ModelDbPath);

    public async Task InitializeAsync() {
        await SqLiteAsyncConnection.CreateTableAsync<ApplicationConfig>();
    }

    public async Task InsertAsync(ApplicationConfig model) {
        await SqLiteAsyncConnection.InsertAsync(model);
    }

    public async Task<IList<ApplicationConfig>> ListAsync() {
        return
            await SqLiteAsyncConnection.Table<ApplicationConfig>().ToListAsync();
    }

    public async Task<IList<ApplicationConfig>> QueryAsync(string keyword) {
        return
            await SqLiteAsyncConnection.Table<ApplicationConfig>().Where(
                item => item.Name != null && item.Name.Contains(keyword)
            ).ToListAsync();
    }
}