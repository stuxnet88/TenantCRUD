using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant.Models
{
  public  class TenantData
    {
        public List<TenantPersonnelModel> Tenants { get; set; }
        public List<GenderModel> Genders { get; set; }

    }
}
