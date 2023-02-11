using ContactApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ContactApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ContactAppController : AbpControllerBase
{
    protected ContactAppController()
    {
        LocalizationResource = typeof(ContactAppResource);
    }
}
