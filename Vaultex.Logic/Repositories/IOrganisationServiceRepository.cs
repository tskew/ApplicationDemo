using System.Collections.Generic;
using Vaultex.Entities;

namespace Vaultex.Logic.Repositories
{
    public interface IOrganisationServiceRepository
    {
        IEnumerable<Organisation> GetOrganisations();
    }
}
