using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Setups.Ports
{
    public interface ISetupRepository<T>
    {
        Task<IList<T>> GetSetupsAsync();
        Task<T> GetSetupAsync(Guid Id);
        Task<T> SaveSetupAsync(T setup);
        Task DeleteSetup(Guid Id);
    }
}
