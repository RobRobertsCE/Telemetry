using iRacing.Setups.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Setups.Adapters
{
    internal class SetupRepository<T> : ISetupRepository<T>
    {
        public Task DeleteSetup(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSetupAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetSetupsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveSetupAsync(T setup)
        {
            throw new NotImplementedException();
        }
    }
}
