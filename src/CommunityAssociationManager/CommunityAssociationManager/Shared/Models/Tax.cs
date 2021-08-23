using System;

namespace CommunityAssociationManager.Shared.Models
{
    public class Tax
    {
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}