using System.Collections.Generic;
using CommunityAssociationManager.Shared.Models;

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
