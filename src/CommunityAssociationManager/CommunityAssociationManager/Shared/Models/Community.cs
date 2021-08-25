using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityAssociationManager.Shared.Models
{
    public class Community
    {
        [Key]
        public uint Id { get; set; }
        public uint ManagerId { get; set; }
        public virtual CommunityMember Manager { get; set; }
        public uint CashierId { get; set; }
        public virtual CommunityMember Cashier { get; set; }
        public virtual IList<CommunityProperty> CommunityProperties { get; set; }
        public virtual IList<Property> Properties { get; set; }
        public virtual IList<RecurringTax> RecurringTaxes { get; set; }
    }
}