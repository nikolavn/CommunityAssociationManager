using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityAssociationManager.Shared.Models
{
    public class CommunityMember
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IList<Property> Properties { get; set; }
        public IList<Tax> Taxes { get; set; }
        public IList<Community> Communities { get; set; }
    }
}
