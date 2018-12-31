using System.Collections.Generic;
using System.Threading.Tasks;
using iRacing.Common.Models;

namespace iRacing.Telemetry.Data.Ports
{
    public interface IUserDefinedFunctionRepository
    {
        bool HasChanges { get; }

        Task<bool> DeleteUserFunctionAsync(IUserDefinedFunction UserFunction);
        Task<bool> DeleteUserFunctionAsync(string key);
        Task<bool> DiscardChanges();
        Task<IUserDefinedFunction> FindUserFunctionAsync(string key);
        Task<IUserDefinedFunction> GetUserFunctionAsync(string name);
        Task<IList<IUserDefinedFunction>> GetUserFunctionsAsync();
        Task<bool> SaveChanges();
        Task<bool> SaveUserFunctionAsync(IUserDefinedFunction UserFunction);
    }
}