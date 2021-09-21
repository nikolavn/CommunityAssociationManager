using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;

namespace CommunityAssociationManager.Server.Repositories
{
    internal interface IPropertyRepository
    {
        Property GetPropertyById(uint propertyId);
        IList<Property> GetAllProperties();
        Property AddProperty(Property property);
        Property UpdateProperty(Property property);
        void DeleteProperty(uint propertyId);
        CommunityMember GetOwner();
        Community GetCommunity();
    }
}
