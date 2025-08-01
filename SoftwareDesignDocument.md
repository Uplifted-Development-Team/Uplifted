## Data Entity Documentation
This document will include the design of the Uplifted data entities to help guide a code-first entity framework database migration.

# INFORMAL NOTES
- In application ESV Bible.

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
  - Role
  - IsActive
  - DateTimeLastActive
 
- Group
  - ID PK
  - Name
  - IsActive
  - HasCustomWeeklyPlan
  - CustomWeeklyPlan FK
 
- UserToGroup
  - ID PK
  - Group.ID FK
  - User.ID FK
  - AccessLevel FK

- GroupMemberDetails
  - ID PK
  - UserToGroup.ID FK
  - GroupWeeklyGoal FK
  - GroupMonthlyGoal FK
  - SobrietyStreakStartDate
  - DailyCheckInStreakStartDate
  
- STDGroupAccessLevels

- GroupWeeklyGoal
  - ID PK
  
- GroupMonthlyGoal
  - ID PK
 
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
  - Scripture (going to have to think of something here to make UX nice. Maybe the user highlights something in scripture and clicks (attach).
