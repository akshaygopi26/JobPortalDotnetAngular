using System.Threading.Tasks;
using JobPortal.Configuration.Dto;

namespace JobPortal.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
