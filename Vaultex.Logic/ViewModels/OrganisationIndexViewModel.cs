using System.Collections.Generic;

namespace Vaultex.Logic.ViewModels
{
    public class OrganisationIndexViewModel
    {
        public IEnumerable<OrganisationModel> Organisations { get; set; } = new List<OrganisationModel>();

        public class OrganisationModel
        {
            public int Id { get; set; }
            public string Number { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
}
