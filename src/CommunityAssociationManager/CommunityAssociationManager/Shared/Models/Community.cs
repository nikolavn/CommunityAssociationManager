using System.Collections.Generic;

namespace CommunityAssociationManager.Shared.Models
{
    public class Community
    {
        public uint Id { get; set; }
        public CommunityMember Manager { get; set; }
        public CommunityMember Cashier { get; set; }
        public IList<CommunityMember> Members { get; set; }
        public IList<Property> CommunityProperties { get; set; }
        public IList<Tax> CommunityTaxes { get; set; }
    }
}