using System.Threading.Tasks;
using Abp.Application.Services;
using JobPortal.Sessions.Dto;

namespace JobPortal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
