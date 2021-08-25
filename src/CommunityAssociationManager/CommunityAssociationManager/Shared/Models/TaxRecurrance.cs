using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityAssociationManager.Shared.Models
{
    public class TaxRecurrance
    {
        [Key]
        public ulong Id { get; set; }
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public uint? PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public uint? CommunityPropertyId { get; set; }
        public virtual CommunityProperty CommunityProperty { get; set; }
        public uint RecurringTaxId { get; set; }
        public virtual RecurringTax RecurringTax { get; set; }
    }
}