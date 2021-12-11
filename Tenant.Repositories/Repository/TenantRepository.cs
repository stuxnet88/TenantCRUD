using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IBaseRepository<TenantPersonnel> _tenantRepository;
        public TenantRepository(IBaseRepository<TenantPersonnel> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public IQueryable<TenantPersonnel> GetTenants()
        {
            var s = _tenantRepository.GetAll();
            return s;
        }
        public TenantPersonnel SaveTenant(TenantPersonnel tenantPersonnel)
        {
            if (tenantPersonnel.TenantId == null)
                _tenantRepository.Insert(tenantPersonnel);
            else
                _tenantRepository.Update(tenantPersonnel);
            return tenantPersonnel;
        }
        public void DeleteTenant(int tenantId)
        {
            var entity = _tenantRepository.GetAll().FirstOrDefault(x => x.TenantId == tenantId);
            _tenantRepository.Delete(entity);
        }
    }
}
