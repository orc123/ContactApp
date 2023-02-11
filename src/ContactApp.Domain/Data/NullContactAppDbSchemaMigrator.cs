using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ContactApp.Data;

/* This is used if database provider does't define
 * IContactAppDbSchemaMigrator implementation.
 */
public class NullContactAppDbSchemaMigrator : IContactAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
