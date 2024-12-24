using System.Collections.Generic;
using System.Threading.Tasks;
using Xioa.AvaApplication.Models;

namespace Xioa.AvaApplication.Services;

public interface IModelStorage {
    Task InitializeAsync();
    Task InsertAsync(ApplicationConfig model);
    Task<IList<ApplicationConfig>> ListAsync();
    Task<IList<ApplicationConfig>> QueryAsync(string keyword);
}