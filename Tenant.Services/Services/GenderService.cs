using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tenant.Models;
using Tenant.Repositories;

namespace Tenant.Services.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public List<GenderModel> GetGenders()
        {
            return _genderRepository.GetGenders().Select(x =>  new GenderModel(x.GenderId, x.Name)).ToList();
        }
    }
}
