using System;
using System.ComponentModel.DataAnnotations;

namespace CommunityAssociationManager.Shared.Models
{
    public class Tax
    {
        [Key]
        public long Id { get; set; }

        public double Amount { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }
    }
}