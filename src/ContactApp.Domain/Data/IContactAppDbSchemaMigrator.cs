using System.Threading.Tasks;

namespace ContactApp.Data;

public interface IContactAppDbSchemaMigrator
{
    Task MigrateAsync();
}
