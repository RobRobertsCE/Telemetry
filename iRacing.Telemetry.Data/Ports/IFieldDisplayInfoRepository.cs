using iRacing.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Data.Ports
{
    public interface IFieldDisplayInfoRepository
    {
        bool HasChanges { get; }

        Task<IFieldDisplayInfo> FindDisplayFieldAsync(string key);
        Task<IFieldDisplayInfo> GetDisplayFieldAsync(string name);
        Task<IList<IFieldDisplayInfo>> GetDisplayFieldsAsync();
        Task<bool> DeleteDisplayFieldAsync(IFieldDisplayInfo displayField);
        Task<bool> DeleteDisplayFieldAsync(string key);
        Task<bool> SaveDisplayFieldAsync(IFieldDisplayInfo displayField);
        Task<bool> SaveDisplayFieldsAsync(IList<IFieldDisplayInfo> displayFields);
        Task<bool> SaveChanges();
        Task<bool> DiscardChanges();
    }
}
