using System.Collections.Generic;

namespace Vaultex.Entities
{
    public class Organisation
    {
        public int Id { get; set; }

        public string OrganisationNumber { get; set; }
        public string OrganisationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
