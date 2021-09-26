using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    internal interface ICommunityRepository
    {
        Community GetCommunityById(uint id);
        Community AddCommunity(Community community);
        Community UpdateCommunity(Community community);
        void DeleteCommunity(int communityId);
        CommunityMember GetManager(Community community);
        Community UpdateManger(Community community, CommunityMember newManager);
        CommunityMember GetCashier(Community community);
        Community UpdateCashier(Community community, CommunityMember newCashier);
        IList<Property> GetAllMemberProperties(Community community);
        IList<CommunityProperty> GetAllCommunityProperties(Community community);
        IList<RecurringTax> GetAllTaxes(Community community);
    }
}
