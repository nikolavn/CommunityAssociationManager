using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    internal interface IPropertyRepository
    {
        Property GetPropertyById(uint propertyId);
        Property AddProperty(Property property);
        Property UpdateProperty(Property property);
        void DeleteProperty(uint propertyId);
        CommunityMember GetOwner(Property property);
        Community GetCommunity(Property property);
        IList<TaxRecurrance> GetTaxRecurrances(Property property);
    }
}
