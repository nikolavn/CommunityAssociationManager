namespace CommunityAssociationManager.Shared.Models
{
    public class CommunityProperty
    {
        public long Id { get; set; }
        public Community Owner { get; set; }
        public Tax Tax { get; set; }
    }
}
