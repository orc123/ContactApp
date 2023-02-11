using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ContactApp;

[Dependency(ReplaceServices = true)]
public class ContactAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ContactApp";
}
