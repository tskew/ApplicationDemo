using System;
using System.Collections.Generic;
using System.Text;
using Vaultex.Logic.Repositories;
using Vaultex.Logic.ViewModels;

namespace Vaultex.Logic.Services
{
    public class OrganisationService
    {
        private readonly IOrganisationServiceRepository repository;

        public OrganisationService(IOrganisationServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public OrganisationIndexViewModel GetOrganisations()
        {
            return new OrganisationIndexViewModel();
        }
    }
}
