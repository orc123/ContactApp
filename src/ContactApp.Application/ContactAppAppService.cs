using System;
using System.Collections.Generic;
using System.Text;
using ContactApp.Localization;
using Volo.Abp.Application.Services;

namespace ContactApp;

/* Inherit your application services from this class.
 */
public abstract class ContactAppAppService : ApplicationService
{
    protected ContactAppAppService()
    {
        LocalizationResource = typeof(ContactAppResource);
    }
}
