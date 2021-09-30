using System.Collections.Generic;
using CommunityAssociationManager.Shared.Models;

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
