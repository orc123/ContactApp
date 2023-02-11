using Volo.Abp.Modularity;

namespace ContactApp;

[DependsOn(
    typeof(ContactAppApplicationModule),
    typeof(ContactAppDomainTestModule)
    )]
public class ContactAppApplicationTestModule : AbpModule
{

}
