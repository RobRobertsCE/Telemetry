using iRacing.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRacing.Telemetry.Data.Ports
{
    public interface IFieldDefinitionRepository
    {
        bool HasChanges { get; }

        Task<IFieldDefinition> FindFieldDefinitionAsync(string key);
        Task<IFieldDefinition> GetFieldDefinitionAsync(string name);
        Task<IList<IFieldDefinition>> GetFieldDefinitionsAsync();
        Task<bool> DeleteFieldDefinitionAsync(IFieldDefinition fieldDefinition);
        Task<bool> DeleteFieldDefinitionAsync(string key);
        Task<bool> SaveFieldDefinitionAsync(IFieldDefinition fieldDefinition);
        Task<bool> SaveFieldDefinitionsAsync(IList<IFieldDefinition> fieldDefinition);
        Task<bool> SaveChanges();
        Task<bool> DiscardChanges();
    }
}
