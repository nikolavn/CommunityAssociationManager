using System.Collections.Generic;
using CommunityAssociationManager.Shared.Models;

namespace CommunityAssociationManager.Server.Repositories
{
    public interface ICommunityMemberRepository
    {
        CommunityMember GetCommunityMemberById(uint communityMemberId);

        CommunityMember AddCommunityMember(CommunityMember communityMember);

        CommunityMember UpdateCommnunityMember(CommunityMember communityMember);

        void RemoveCommunityMember(uint communityMemberId);
    }
}
