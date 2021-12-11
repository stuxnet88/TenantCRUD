using System;
using System.Collections.Generic;
using System.Text;
using Tenant.Models;

namespace Tenant.Services
{
    public interface ITenantService
    {
        List<TenantPersonnelModel> GetTenants();
        TenantPersonnelModel SaveTenant(TenantPersonnelModel Tenant);
        void DeleteTenant(int Tenant);
    }
}
