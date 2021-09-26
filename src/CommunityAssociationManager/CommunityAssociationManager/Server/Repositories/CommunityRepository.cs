using CommunityAssociationManager.Server.Data;
using CommunityAssociationManager.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace CommunityAssociationManager.Server.Repositories
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CommunityRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Community AddCommunity(Community community)
        {
            var addedCommunity = this.applicationDbContext.Communities.Add(community);
            this.applicationDbContext.SaveChangesAsync();
            return addedCommunity.Entity;
        }

        public void DeleteCommunity(int communityId)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == communityId);
            if (currentCommunity == null) return;

            this.applicationDbContext.Communities.Remove(currentCommunity);
            this.applicationDbContext.SaveChangesAsync();
        }

        public IList<CommunityProperty> GetAllCommunityProperties(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            return currentCommunity.CommunityProperties ?? null;
        }

        public IList<Property> GetAllMemberProperties(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            return currentCommunity.Properties ?? null;
        }

        public IList<RecurringTax> GetAllTaxes(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            return currentCommunity.RecurringTaxes ?? null;
        }

        public CommunityMember GetCashier(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            return currentCommunity.Cashier ?? null;
        }

        public Community GetCommunityById(uint id)
        {
            return this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == id);
        }

        public CommunityMember GetManager(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            return currentCommunity.Manager ?? null;
        }

        public Community UpdateCashier(Community community, CommunityMember newCashier)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            if (currentCommunity == null || !this.CheckIsCommunityMember(community, newCashier)) return null;
            currentCommunity.Cashier = newCashier;
            this.applicationDbContext.SaveChangesAsync();
            return currentCommunity;
        }

        public Community UpdateCommunity(Community community)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            if (currentCommunity != null)
            {
                currentCommunity.Id = community.Id;
                currentCommunity.Cashier = community.Cashier;
                currentCommunity.CashierId = community.CashierId;
                currentCommunity.Manager = community.Manager;
                currentCommunity.ManagerId = community.ManagerId;
                currentCommunity.CommunityProperties = community.CommunityProperties;
                currentCommunity.Properties = community.Properties;
                currentCommunity.RecurringTaxes = community.RecurringTaxes;

                this.applicationDbContext.SaveChangesAsync();

                return currentCommunity;
            }
            return null;
        }

        public Community UpdateManger(Community community, CommunityMember newManager)
        {
            var currentCommunity = this.applicationDbContext.Communities.FirstOrDefault(c => c.Id == community.Id);
            if (currentCommunity == null || !this.CheckIsCommunityMember(community, newManager)) return null;
            currentCommunity.Manager = newManager;
            this.applicationDbContext.SaveChangesAsync();
            return currentCommunity;
        }

        private bool CheckIsCommunityMember(Community community, CommunityMember member)
        {
            var communityMembers = community.Properties.Select(p => p.Owner).ToList();
            var isMember = communityMembers.Any(cm => cm.Id == member.Id);

            return isMember;
        }
    }
}
