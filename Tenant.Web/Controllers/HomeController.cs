using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tenant.Models;
using Tenant.Services;
using Tenant.Web.Models;

namespace Tenant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITenantService _tenantService;
        private readonly IGenderService _genderService;
        public HomeController(ILogger<HomeController> logger, ITenantService tenantService, IGenderService genderService)
        {
            _logger = logger;
            _tenantService = tenantService;
            this._genderService = genderService;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult GetTenants()
        {
            TenantData TenantData = new TenantData();
            TenantData.Tenants = new List<TenantPersonnelModel>();
            TenantData.Tenants = _tenantService.GetTenants();
            TenantData.Genders = _genderService.GetGenders();
            return Ok(TenantData);
        }
        [HttpPost]
        public IActionResult EditTenant(TenantPersonnelModel tenant)
        {
            TenantPersonnelModel TenantPersonnel = _tenantService.SaveTenant(tenant);
            return Ok(tenant);
        }
        [HttpPost]
        public IActionResult DeleteTenant(int tenantId)
        {
            _tenantService.DeleteTenant(tenantId);
            return Ok();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
