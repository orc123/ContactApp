using Volo.Abp.Settings;

namespace ContactApp.Settings;

public class ContactAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ContactAppSettings.MySetting1));
    }
}
