using CommunityAssociationManager.Server.Data;
using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommunityAssociationManager.Server.Repositories
{
    internal class CommunityMemberRepository : ICommunityMemberRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CommunityMemberRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public CommunityMember AddCommunityMember(CommunityMember communityMember)
        {
            var addedCommunityMember = this.applicationDbContext.CommunityMembers.Add(communityMember);
            this.applicationDbContext.SaveChangesAsync();
            return addedCommunityMember.Entity;
        }

        public IList<Community> GetCashieredCommunities(CommunityMember communityMember)
        {
            var currentMember = this.applicationDbContext.CommunityMembers.FirstOrDefault(cm => cm.Id == communityMember.Id);
            return currentMember.CashierCommunities ?? null;
        }

        public CommunityMember GetCommunityMemberById(uint communityMemberId)
        {
            return this.applicationDbContext.CommunityMembers.FirstOrDefault(cm =>  cm.Id == communityMemberId);
        }

        public IList<Property> GetCommunityMemberProperties(CommunityMember communityMember)
        {
            var currentMember = this.applicationDbContext.CommunityMembers.FirstOrDefault(cm => cm.Id == communityMember.Id);
            return currentMember.Properties ?? null;
        }

        public IList<Community> GetManagedCommunities(CommunityMember communityMember)
        {
            var currentMember = this.applicationDbContext.CommunityMembers.FirstOrDefault(cm => cm.Id == communityMember.Id);
            return currentMember.ManagedCommunities ?? null;
        }

        public void RemoveCommunityMember(uint communityMemberId)
        {
            var currentMember = this.applicationDbContext.CommunityMembers.FirstOrDefault(cm => cm.Id == communityMemberId);
            if (currentMember == null) return;

            this.applicationDbContext.CommunityMembers.Remove(currentMember);
            this.applicationDbContext.SaveChangesAsync();
        }

        public CommunityMember UpdateCommnunityMember(CommunityMember communityMember)
        {
            var currentMember = this.applicationDbContext.CommunityMembers.FirstOrDefault(cm => cm.Id == communityMember.Id);

            if (currentMember != null)
            {
                currentMember.Name = communityMember.Name;
                currentMember.Address = communityMember.Address;
                currentMember.City = communityMember.City;
                currentMember.Country = communityMember.Country;
                currentMember.Email = communityMember.Email;
                currentMember.Phone = communityMember.Phone;
                currentMember.Properties = communityMember.Properties;
                currentMember.ManagedCommunities = communityMember.ManagedCommunities;
                currentMember.CashierCommunities = communityMember.CashierCommunities;

                this.applicationDbContext.SaveChangesAsync();

                return currentMember;
            }

            return null;
        }
    }
}
