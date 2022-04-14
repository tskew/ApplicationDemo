using System;
using Microsoft.AspNetCore.Mvc;
using Vaultex.Logic.Services;
using Vaultex.Logic.ViewModels;

namespace Vaultex.Web.Controllers
{
    public class OrganisationsController : Controller
    {
        private readonly IOrganisationService organisationService;

        public OrganisationsController(IOrganisationService organisationService)
        {
            this.organisationService = organisationService ?? throw new ArgumentNullException(nameof(organisationService));
        }

        public IActionResult Index()
        {
            OrganisationIndexViewModel organisationsModel = organisationService.GetOrganisations();

            return View(organisationsModel);
        }
    }
}