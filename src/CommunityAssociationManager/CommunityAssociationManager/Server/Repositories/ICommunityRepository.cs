using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    public interface ICommunityRepository
    {
        Community GetCommunityById(uint id);
        Community AddCommunity(Community community);
        Community UpdateCommunity(Community community);
        void DeleteCommunity(uint communityId);
        CommunityMember GetManager(Community community);
        Community UpdateManger(Community community, CommunityMember newManager);
        CommunityMember GetCashier(Community community);
        Community UpdateCashier(Community community, CommunityMember newCashier);
        IList<Property> GetAllMemberProperties(Community community);
        IList<CommunityProperty> GetAllCommunityProperties(Community community);
        IList<Community> GetManagedCommunitiesForMember(CommunityMember communityMember);
        IList<Community> GetCashieredCommunitiesForMember(CommunityMember communityMember);
        IList<RecurringTax> GetAllTaxes(Community community);
    }
}
