using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityAssociationManager.Shared.Models
{
    public class CommunityProperty
    {
        [Key]
        public long Id { get; set; }

        public uint OwnerId { get; set; }

        public virtual Community Owner { get; set; }

        public virtual IList<TaxRecurrance> TaxRecurrances { get; set; }
    }
}
