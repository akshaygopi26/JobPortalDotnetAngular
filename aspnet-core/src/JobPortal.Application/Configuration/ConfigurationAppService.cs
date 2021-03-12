using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JobPortal.Configuration.Dto;

namespace JobPortal.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JobPortalAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
