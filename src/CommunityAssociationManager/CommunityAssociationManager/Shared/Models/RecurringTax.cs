using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityAssociationManager.Shared.Models
{
    public class RecurringTax
    {
        [Key]
        public long Id { get; set; }
        public uint CommunityId { get; set; }
        public virtual Community Community { get; set; }
        public virtual IList<TaxRecurrance> TaxRecurrances { get; set; }
    }
}