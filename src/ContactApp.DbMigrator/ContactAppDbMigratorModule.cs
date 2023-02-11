using ContactApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ContactApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ContactAppEntityFrameworkCoreModule),
    typeof(ContactAppApplicationContractsModule)
    )]
public class ContactAppDbMigratorModule : AbpModule
{

}
