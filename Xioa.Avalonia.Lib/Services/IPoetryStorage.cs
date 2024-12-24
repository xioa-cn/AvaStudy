using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xioa.Avalonia.Lib.Helpers;
using Xioa.Avalonia.Lib.Models;

namespace Xioa.Avalonia.Lib.Services;

public interface IPoetryStorage {
    bool IsInitialized { get; }
    Task InitializeAsync();
    Task<Poetry> GetPoetryAsync(int id);

    Task<IList<Poetry>> GetPoetriesAsync(
        Expression<Func<Poetry, bool>> where, int skip, int take);
}