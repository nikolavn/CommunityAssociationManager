using CommunityAssociationManager.Server.Repositories;
using CommunityAssociationManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAssociationManager.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetPropertyById(uint id)
        {
            return this.Ok(this.propertyRepository.GetPropertyById(id));
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] Property property)
        {
            if (property == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var createdProperty = this.propertyRepository.AddProperty(property);

            return this.Created("property", createdProperty);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (property == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var propertyToUpdate = this.propertyRepository.GetPropertyById(property.Id);

            if (propertyToUpdate == null)
                return this.NotFound();

            this.propertyRepository.UpdateProperty(propertyToUpdate);

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(long id)
        {
            if (id == 0)
                return this.BadRequest();

            var propertyToDelete = this.propertyRepository.GetPropertyById(id);

            if (propertyToDelete == null)
                return this.NotFound();
            this.propertyRepository.DeleteProperty(id);

            return this.NoContent();
        }
    }
}
