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
  - ID: INT PK
  - UserID: VARCHAR(32)
  - UserName: VARCHAR(32)
  - Email: VARCHAR(64)
  - Password: VARCHAR(256)
  - FirstName: VARCHAR(32)
  - LastName: VARCHAR(32)
  - IsActive: BOOLEAN
  - DateTimeLastActive: DATETIME
 
- STDRole
  - RoleID: INT PK
  - Name: VARCHAR(32)
  - Description: TEXT

- UserToRole
  - ID: INT PK
  - UserID: INT (User.ID) FK
  - RoleID: INT (STDRole.ID) FK
 
- Group
  - ID: INT PK
  - Name: VARCHAR(32)
  - IsActive: BOOLEAN
  - CustomWeeklyPlan FK (nulllable->WeeklyPlan)

- STDGroupAccessLevel
  - AccessLevelID: INT PK
  - Name: VARCHAR(32)

- GroupMember
  - ID: INT PK
  - Group.ID: INT FK
  - User.ID: INT FK
  - AccessLevelID: INT FK
  - JoinedAt: DATETIME

- GroupMemberDetails
  - ID PK
  - UserToGroup.ID FK
  - GroupWeeklyGoal FK
  - GroupMonthlyGoal FK
  - SobrietyStreakStartDate
  - DailyCheckInStreakStartDate

- GroupWeeklyGoal
  - ID: INT PK
  - Title: VARCHAR(32)
  - Description: TEXT
  - DateTimeStreakStart: DATETIME
  - GroupMember.ID: INT FK
  
- GroupMonthlyGoal
  - ID: INT PK
  - HasStreaks: BOOLEAN
  - Description: TEXT
  - DateTimeStreakStart: DATETIME
  - GroupMember.ID: INT FK
 
- GroupChat
  - ID: INT PK
  - Group.ID: INT FK
  - Name: VARCHAR(32)
  - Description: TEXT
  - DateTimeCreated: DATETIME
  - DateTimeLastActive: DATETIME
  - DateTimeLastUpdated: DATETIME
 
- GroupChatMessage
  - ID: INT PK
  - GroupChat.ID: INT FK
  - Sender: INT (User.ID) FK
  - Message: TEXT
  - isEdited: BOOLEAN
  - isSystem: BOOLEAN
  - CreatedAt: DATETIME
  - ParentMessage: INT (GroupChatMessage.ID)

- GroupChatMessageAttachments
  - ID: INT PK
  - GroupChatMessage.ID: INT FK
  - FileURL: VARCHAR(512)
  - FileType: VARCHAR(16)
  - DateTimeCreated: DATETIME
 
- Notifications (DON'T DEVELOP YET)
  - ID: INT PK
  - Status: VARCHAR(16)
  - GroupChatMessage.ID: INT FK
  - UserToNotify: INT (User.ID) FK
  - Category: INT FK
  - ...MORE ON THIS LATER
 
- STDNotificationCategories

- GroupPrayerRequests
  - ID: INT PK
  - Title: VARCHAR(32)
  - Description: TEXT
  - UserToGroup.ID: INT FK
  - DateTimeCreated: DATETIME
  - IsFulfilled: BOOLEAN
 
- GroupPrayerRequestsScriptureAttachments
  - ID: INT PK
  - GroupPrayerRequest.ID: INT FK
  - UserWhoAttached: INT (User.ID) FK
  - Scripture (going to have to think of something here to make UX nice. Maybe the user highlights something in scripture and clicks attach).
 
- UpliftedAppEvents
  - ID: INT FK
  - User.ID: INT FK
  - EventSource: VARCHAR(64)
  - EventMessage: TEXT
  - DateTimeCreated: DATETIME
