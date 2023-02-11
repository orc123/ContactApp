using ContactApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ContactApp.Blazor;

public abstract class ContactAppComponentBase : AbpComponentBase
{
    protected ContactAppComponentBase()
    {
        LocalizationResource = typeof(ContactAppResource);
    }
}
