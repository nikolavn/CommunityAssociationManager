using CommunityAssociationManager.Server.Repositories;
using CommunityAssociationManager.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAssociationManager.Server.Controllers
{
    [Route("api/[controller]/[action]")]
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
            return this.Ok(this.communityMemberRepository.GetCommunityMemberById(id));
        }

        [HttpPost]
        public IActionResult CreateProperty([FromBody] CommunityMember communityMember)
        {
            if (communityMember == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var createdMember = this.communityMemberRepository.AddCommunityMember(communityMember);

            return this.Created("member", createdMember);
        }

        [HttpPut]
        public IActionResult UpdateProperty([FromBody] CommunityMember communityMember)
        {
            if (communityMember == null)
                return this.BadRequest();

            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            var memberToUpdate = this.communityMemberRepository.GetCommunityMemberById(communityMember.Id);

            if (memberToUpdate == null)
                return this.NotFound();

            this.communityMemberRepository.UpdateCommnunityMember(memberToUpdate);

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(uint id)
        {
            if (id == 0)
                return this.BadRequest();

            var memberToDelete = this.communityMemberRepository.GetCommunityMemberById(id);

            if (memberToDelete == null)
                return this.NotFound();
            this.communityMemberRepository.RemoveCommunityMember(id);

            return this.NoContent();
        }
    }
}
