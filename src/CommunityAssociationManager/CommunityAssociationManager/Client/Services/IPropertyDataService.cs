using System.Threading.Tasks;
using CommunityAssociationManager.Shared.Models;

namespace CommunityAssociationManager.Client.Services
{
    public interface IPropertyDataService
    {
        Task<Property> GetPropertyById(long propertyId);
    }
}
