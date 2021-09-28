using CommunityAssociationManager.Server.Repositories;
using CommunityAssociationManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAssociationManager.Server.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(this.propertyRepository.GetPropertyById(id));
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] Property property)
        {
            if (property == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProperty = this.propertyRepository.AddProperty(property);

            return Created("property", createdProperty);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (property == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propertyToUpdate = this.propertyRepository.GetPropertyById(property.Id);

            if (propertyToUpdate == null)
                return NotFound();

            this.propertyRepository.UpdateProperty(propertyToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(long id)
        {
            if (id == 0)
                return BadRequest();

            var propertyToDelete = this.propertyRepository.GetPropertyById(id);

            if (propertyToDelete == null)
                return NotFound();
            this.propertyRepository.DeleteProperty(id);

            return NoContent();
        }
    }
}
