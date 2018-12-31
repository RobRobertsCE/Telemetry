using System.Collections.Generic;
using System.Threading.Tasks;
using iRacing.Common.Models;

namespace iRacing.Telemetry.Data.Ports
{
    public interface IFunctionRepository
    {
        bool HasChanges { get; }

        Task<bool> DeleteFunctionAsync(IFunction function);
        Task<bool> DeleteFunctionAsync(string key);
        Task<bool> DiscardChanges();
        Task<IFunction> FindFunctionAsync(string key);
        Task<IFunction> GetFunctionAsync(string name);
        Task<IList<IFunction>> GetFunctionsAsync();
        Task<bool> SaveChanges();
        Task<bool> SaveFunctionAsync(IFunction function);
    }
}