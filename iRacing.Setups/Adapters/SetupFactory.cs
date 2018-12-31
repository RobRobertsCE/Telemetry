using iRacing.Setups.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.Setups.Adapters
{
    internal class SetupFactory<Guid> : ISetupFactory<Guid>
    {
        public Task<Guid> ParseSetupAsync(string yaml)
        {
            throw new NotImplementedException();
        }
    }
}
