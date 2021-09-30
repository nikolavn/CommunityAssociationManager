using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityAssociationManager.Shared.Models
{
    public class Property
    {
        [Key]
        public long Id { get; set; }

        public uint OwnerId { get; set; }

        public virtual CommunityMember Owner { get; set; }

        public uint CommunityId { get; set; }

        public virtual Community Community { get; set; }

        public string Address { get; set; }

        public virtual IList<TaxRecurrance> TaxRecurrances { get; set; }
    }
}