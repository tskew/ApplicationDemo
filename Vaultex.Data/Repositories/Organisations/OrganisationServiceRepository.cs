using System;
using System.Collections.Generic;
using Vaultex.Entities;
using Vaultex.Logic.Repositories;

namespace Vaultex.Data.Repositories.Organisations
{
    public class OrganisationServiceRepository : IOrganisationServiceRepository
    {
        private readonly DataContext context;

        public OrganisationServiceRepository(DataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Organisation> GetOrganisations()
        {
            return context.Organisations;
        }
    }
}
