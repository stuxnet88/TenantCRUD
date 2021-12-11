
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant.Repositories
{
    public interface IGenderRepository
    {
        IQueryable<Gender> GetGenders();
    }
}
