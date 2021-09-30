using CommunityAssociationManager.Server.Repositories;
using CommunityAssociationManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAssociationManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : Controller
    {
        private readonly ICommunityRepository communityRepository;

        public CommunityController(ICommunityRepository communityRepository)
        {
            this.communityRepository = communityRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetCommunityById(uint id)
        {
            return this.Ok(this.communityRepository.GetCommunityById(id));
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] Community community)
        {
            if (community == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var createdCommunity = this.communityRepository.AddCommunity(community);

            return this.Created("community", createdCommunity);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] Community community)
        {
            if (community == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var communityToUpdate = this.communityRepository.GetCommunityById(community.Id);

            if (communityToUpdate == null)
                return this.NotFound();

            this.communityRepository.UpdateCommunity(communityToUpdate);

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(uint id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            var communityToDelete = this.communityRepository.GetCommunityById(id);

            if (communityToDelete == null)
            {
                return this.NotFound();
            }

            this.communityRepository.DeleteCommunity(id);

            return this.NoContent();
        }
    }
}
