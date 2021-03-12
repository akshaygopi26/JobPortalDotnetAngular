using Abp.Application.Services;
using JobPortal.MultiTenancy.Dto;

namespace JobPortal.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

