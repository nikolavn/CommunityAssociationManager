using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Shared.Repositories
{
    internal interface ICommunityRepository
    {
        Community GetCommunity(uint id);
        Community AddCommunity(Community community);
        Community UpdateCommunity(Community community);
        void DeleteCommunity(int communityId);
        CommunityMember GetManager();
        CommunityMember UpdateManger(CommunityMember manager);
        CommunityMember GetCashier();
        CommunityMember UpdateCashier();
        IList<Property> GetAllMemberProperties();
        IList<Property> GetAllCommunityProperties();
        IList<RecurringTax> GetAllTaxes();
    }
}
