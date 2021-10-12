using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    public interface IPropertyRepository
    {
        Property GetPropertyById(long propertyId);
        Property AddProperty(Property property);
        Property UpdateProperty(Property property);
        void DeleteProperty(long propertyId);
        CommunityMember GetOwner(Property property);
        Community GetCommunity(Property property);
        IList<Property> GetCommunityMemberProperties(CommunityMember communityMember);
        IList<TaxRecurrance> GetTaxRecurrances(Property property);
    }
}
