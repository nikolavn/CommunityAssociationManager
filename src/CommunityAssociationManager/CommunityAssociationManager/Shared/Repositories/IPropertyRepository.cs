using System.Collections.Generic;
using CommunityAssociationManager.Shared.Models;

namespace CommunityAssociationManager.Shared.Repositories
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
