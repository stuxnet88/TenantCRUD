using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tenant.Models;
using Tenant.Repositories;

namespace Tenant.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public List<TenantPersonnelModel> GetTenants()
        {
            return _tenantRepository.GetTenants().Select(x => new TenantPersonnelModel(x.TenantId, x.FirstName, x.NickName, x.LastName,x.MiddleName, x.DOB, x.Active, x.PrefixId,x.GenderFk.GenderId)).ToList();
        }
        public TenantPersonnelModel SaveTenant(TenantPersonnelModel Tenant)
        {
            TenantPersonnel TenantData= _tenantRepository.SaveTenant(new TenantPersonnel(Tenant.TenantId,Tenant.FirstName,Tenant.NickName,Tenant.LastName,Tenant.MiddleName,Tenant.DOB,Tenant.Active,Tenant.PrefixId,Tenant.GenderId));
            return new TenantPersonnelModel(TenantData.TenantId, TenantData.FirstName, TenantData.NickName, TenantData.LastName, TenantData.MiddleName, TenantData.DOB, TenantData.Active, TenantData.PrefixId, TenantData.GenderId);
        }
        public void DeleteTenant(int Tenant)
        {
             _tenantRepository.DeleteTenant(Tenant);
        }

    }
}
