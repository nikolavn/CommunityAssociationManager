using CommunityAssociationManager.Server.Repositories;
using CommunityAssociationManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAssociationManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityMemberController : Controller
    {
        private readonly ICommunityMemberRepository communityMemberRepository;

        public CommunityMemberController(ICommunityMemberRepository communityMemberRepository)
        {
            this.communityMemberRepository = communityMemberRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetCommunityMemberById(uint id)
        {
            return Ok(this.communityMemberRepository.GetCommunityMemberById(id));
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] CommunityMember communityMember)
        {
            if (communityMember == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMember = this.communityMemberRepository.AddCommunityMember(communityMember);

            return Created("member", createdMember);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] CommunityMember communityMember)
        {
            if (communityMember == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var memberToUpdate = this.communityMemberRepository.GetCommunityMemberById(communityMember.Id);

            if (memberToUpdate == null)
                return NotFound();

            this.communityMemberRepository.UpdateCommnunityMember(memberToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(uint id)
        {
            if (id == 0)
                return BadRequest();

            var memberToDelete = this.communityMemberRepository.GetCommunityMemberById(id);

            if (memberToDelete == null)
                return NotFound();
            this.communityMemberRepository.RemoveCommunityMember(id);

            return NoContent();
        }
    }
}
