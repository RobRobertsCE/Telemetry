using System.Threading.Tasks;

namespace iRacing.Setups.Ports
{
    public interface ISetupFactory<T>
    {
        Task<T> ParseSetupAsync(string yaml);
    }
}
