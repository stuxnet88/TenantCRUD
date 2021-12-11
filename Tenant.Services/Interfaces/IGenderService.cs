using System;
using System.Collections.Generic;
using System.Text;
using Tenant.Models;

namespace Tenant.Services
{
    public interface IGenderService
    {
        List<GenderModel> GetGenders();
    }
}
