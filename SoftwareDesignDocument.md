# Galatians 6:2: "Carry each other’s burdens, and in this way, you will fulfill the law of Christ."
# James 5:16: "Therefore confess your sins to each other and pray for each other so that you may be healed. The prayer of a righteous person is powerful and effective."
# Proverbs 27:17: "As iron sharpens iron, so one person sharpens another."
## Data Entity Documentation
This document will include the design of the Uplifted data entities to help guide a code-first entity framework database migration.

# INFORMAL NOTES
- In application ESV Bible (https://api.esv.org/docs/samples/).

## Design
### Possible Entities from Requirements
Entities will include data, views, and their methods.

- User (Role Based Credentials)
  - ID PK
  - UserID
  - UserName
  - Email
  - Password
  - FirstName
  - LastName
  - IsActive
  - DateTimeLastActive
 
- STDRole
  - RoleID PK
  - Name
  - Description

- UserToRole
  - ID PK
  - UserID (User.ID) FK
  - RoleID (STDRole.ID) FK
 
- Group
  - ID PK
  - Name
  - IsActive
  - CustomWeeklyPlan FK (nulllable->WeeklyPlan)

- STDGroupAccessLevel
  - AccessLevelID PK
  - Name

- GroupMember
  - ID PK
  - Group.ID FK
  - User.ID FK
  - AccessLevelID FK
  - JoinedAt

- GroupMemberDetails
  - ID PK
  - UserToGroup.ID FK
  - GroupWeeklyGoal FK
  - GroupMonthlyGoal FK
  - SobrietyStreakStartDate
  - DailyCheckInStreakStartDate

- GroupWeeklyGoal
  - ID PK
  - Title
  - Description
  - DateTimeStreakStart
  - GroupMember.ID FK
  
- GroupMonthlyGoal
  - ID PK
  - Has streaks
  - Description
  - DateTimeStreakStart
  - GroupMember.ID FK
 
- GroupChat
  - ID PK
  - Group.ID FK
  - Name
  - Description
  - DateTimeCreated
  - DateTimeLastActive
  - DateTimeLastUpdated
 
- GroupChatMessage
  - ID PK
  - GroupChat.ID FK
  - Sender (User.ID) FK
  - Message
  - isEdited
  - isSystem
  - CreatedAt
  - ParentMessage (GroupChatMessage.ID)

- GroupChatMessageAttachments
  - ID PK
  - GroupChatMessage.ID FK
  - FileURL
  - FileType
  - DateTimeCreated
 
- Notifications (DON'T DEVELOP YET)
  - ID PK
  - Status
  - GroupChatMessage.ID FK
  - UserToNotify (User.ID) FK
  - Category FK
  - ...MORE ON THIS LATER
 
- STDNotificationCategories

- GroupPrayerRequests
  - ID PK
  - Title
  - Description
  - UserToGroup.ID FK
  - DateTimeCreated
  - IsFulfilled
 
- GroupPrayerRequestsScriptureAttachments
  - ID PK
  - GroupPrayerRequest.ID FK
  - UserWhoAttached (User.ID) FK
  - Scripture (going to have to think of something here to make UX nice. Maybe the user highlights something in scripture and clicks attach).
 
- UpliftedAppEvents
  - ID FK
  - User.ID FK
  - EventSource
  - EventMessage
  - DateTimeCreated
