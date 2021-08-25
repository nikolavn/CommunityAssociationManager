using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityAssociationManager.Shared.Models
{
    public class CommunityMember
    {
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual IList<Property> Properties { get; set; }

        public virtual IList<Community> ManagedCommunities { get; set; } 

        // TODO: Rename?
        public virtual IList<Community> CashierCommunities { get; set; }

    }
}
