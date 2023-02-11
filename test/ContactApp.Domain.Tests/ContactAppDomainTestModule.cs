using ContactApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ContactApp;

[DependsOn(
    typeof(ContactAppEntityFrameworkCoreTestModule)
    )]
public class ContactAppDomainTestModule : AbpModule
{

}
