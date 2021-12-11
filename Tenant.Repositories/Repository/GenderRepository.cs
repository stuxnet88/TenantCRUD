using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant.Repositories
{
   public class GenderRepository:IGenderRepository
    {
        private readonly IBaseRepository<Gender> _genderRepository;
        public GenderRepository(IBaseRepository<Gender> genderRepository)
        {
            this._genderRepository = genderRepository;
        }
        public IQueryable<Gender> GetGenders()
        {
            return _genderRepository.GetAll();
        }
    }
}
