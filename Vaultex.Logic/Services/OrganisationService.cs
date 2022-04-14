using System;
using System.Collections.Generic;
using System.Linq;
using Vaultex.Entities;
using Vaultex.Logic.Repositories;
using Vaultex.Logic.ViewModels;

namespace Vaultex.Logic.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IOrganisationServiceRepository repository;

        public OrganisationService(IOrganisationServiceRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public OrganisationIndexViewModel GetOrganisations()
        {
            IEnumerable<Organisation> organisations = repository.GetOrganisations();

            return new OrganisationIndexViewModel()
            {
                Organisations = organisations.Select(o => new OrganisationIndexViewModel.OrganisationModel
                {
                    Id = o.Id,
                    Name = o.OrganisationName,
                    Number = o.OrganisationNumber,
                    Address = GetAddress(o)
                })
            };
        }

        public string GetAddress(Organisation organisation)
        {
            return $"{organisation.AddressLine1}, {(string.IsNullOrWhiteSpace(organisation.AddressLine2) ? "" : organisation.AddressLine2 + ", ")}{organisation.Town}. {organisation.PostCode}";
        }
    }
}
