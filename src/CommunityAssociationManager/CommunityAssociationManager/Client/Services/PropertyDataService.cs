using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityAssociationManager.Shared.Models;

namespace CommunityAssociationManager.Client.Services
{
    public class PropertyDataService : IPropertyDataService
    {
        private readonly HttpClient client;

        public PropertyDataService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Property> GetPropertyById(long propertyId)
        {
            return await JsonSerializer.DeserializeAsync<Property>
                (await this.client.GetStreamAsync($"api/property/{propertyId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
