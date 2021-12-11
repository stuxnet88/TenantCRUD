using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant.Repositories
{
    public interface ITenantRepository
    {
        IQueryable<TenantPersonnel> GetTenants();
        TenantPersonnel SaveTenant(TenantPersonnel tenantPersonnel);
        void DeleteTenant(int id);

    }
}
