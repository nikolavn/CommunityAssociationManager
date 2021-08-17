# CommunityAssociationManagerApp

### CommunityMember

 - string => Name
 - Contacts(mail, phone etc.)
 - IList Property => Properties

### CommunityBoardMember : CommunityMember

 - IsCommunityManager
 - IsCommunityCashier


### Community

 - CommunityMember => Manager
 - CommunityMember => Cashier
 - IList CommunityMember => CommunityMembers
 - IList Property => CommunityProperties
 - Ilist Tax => CommunityTaxes

 ### Tax

 - Amount
 - DueDate
 - IsPaid

 ### RecurringTax : Tax

 - RecurrancePeriod

 ### Property

 - CommunityMember => Owner
 - Tax => Tax

 ### CommunityProperty

 - Community => Owner
 - Tax => Tax
