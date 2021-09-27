using CommunityAssociationManager.Server.Data;
using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommunityAssociationManager.Server.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public PropertyRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Property AddProperty(Property property)
        {
            var addedProperty = this.applicationDbContext.Properties.Add(property);
            this.applicationDbContext.SaveChangesAsync();
            return addedProperty.Entity;
        }

        public void DeleteProperty(long propertyId)
        {
            var currentProperty = this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == propertyId);
            if (currentProperty == null) return;

            this.applicationDbContext.Properties.Remove(currentProperty);
            this.applicationDbContext.SaveChangesAsync();
        }

        public Community GetCommunity(Property property)
        {
            var currentProperty = this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == property.Id);
            return currentProperty.Community ?? null;
        }

        public CommunityMember GetOwner(Property property)
        {
            var currentProperty = this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == property.Id);
            return currentProperty.Owner ?? null;
        }

        public Property GetPropertyById(long propertyId)
        {
            return this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == propertyId);
        }

        public IList<TaxRecurrance> GetTaxRecurrances(Property property)
        {
            var currentProperty = this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == property.Id);
            return currentProperty.TaxRecurrances ?? null;
        }

        public Property UpdateProperty(Property property)
        {
            var currentProperty = this.applicationDbContext.Properties.FirstOrDefault(p => p.Id == property.Id);
            if (currentProperty != null) 
            {
                currentProperty.Id = property.Id;
                currentProperty.OwnerId = property.OwnerId;
                currentProperty.Owner = property.Owner;
                currentProperty.CommunityId = property.CommunityId;
                currentProperty.Community = property.Community;
                currentProperty.Address = property.Address;
                currentProperty.TaxRecurrances = property.TaxRecurrances;

                this.applicationDbContext.SaveChangesAsync();
                return currentProperty;
            }
            return  null;
        }
    }
}
