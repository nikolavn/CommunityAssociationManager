using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Shared.Repositories
{
    internal interface ICommunityMemberRepository
    {
        CommunityMember GetCommunityMember(uint communityMemberId);
        CommunityMember AddCommunityMember(CommunityMember communityMember);
        CommunityMember UpdateCommnunityMember(CommunityMember communityMember);
        void RemoveCommunityMember(uint communityMemberId);
        IList<Property> GetCommunityMemberProperties();
        IList<Community> GetManagedCommunities();
        IList<Community> GetCashieredCommunities();
    }
}
