using ContactApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ContactApp.Permissions;

public class ContactAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ContactAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ContactAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ContactAppResource>(name);
    }
}
