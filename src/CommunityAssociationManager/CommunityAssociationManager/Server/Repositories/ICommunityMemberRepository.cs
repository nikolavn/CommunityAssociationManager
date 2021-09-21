using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    internal interface ICommunityMemberRepository
    {
        CommunityMember GetCommunityMemberById(uint communityMemberId);
        CommunityMember AddCommunityMember(CommunityMember communityMember);
        CommunityMember UpdateCommnunityMember(CommunityMember communityMember);
        void RemoveCommunityMember(uint communityMemberId);
        IList<Property> GetCommunityMemberProperties(CommunityMember communityMember);
        IList<Community> GetManagedCommunities(CommunityMember communityMember);
        IList<Community> GetCashieredCommunities(CommunityMember communityMember);
    }
}
