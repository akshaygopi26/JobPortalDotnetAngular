using System.Threading.Tasks;
using Abp.Application.Services;
using JobPortal.Authorization.Accounts.Dto;

namespace JobPortal.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
