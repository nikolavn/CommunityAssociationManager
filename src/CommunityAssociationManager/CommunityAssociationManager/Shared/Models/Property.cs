namespace CommunityAssociationManager.Shared.Models
{
    public class Property
    {
        public long Id { get; set; }
        public CommunityMember Owner { get; set; }
        public Tax Tax { get; set; }
    }
}