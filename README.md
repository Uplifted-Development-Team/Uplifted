# Uplifted
Source code repository for the Uplifted Discipleship and Accountability Hybrid Application

### 🚀 Core Features
- User Authentication and Authorization – Secure sign-up, login, password reset, and role-based access control  
- User Profile Management – View and update personal details, preferences, and account settings  
- CRUD operations on all core entities  
- Create groups filled with users  
- Add and remove users from groups  
- Morning and evening accountability reports  
- Responding abilities to accountability reports  
- Weekly accountability reports  
- Monthly accountability reports  
- Accountability report streaks  
- Default weekly plans  
- Bug report button  
- Threaded replies  
- @mentions in group chat  
- Announcements and pinned messages per group  
- Dashboard with streaks, completion rates  
- Trend analysis and predictive insights  
- Application logs  
- Hierarchical personal goals (annual, quarterly, weekly)  
- Notifications for chats  
- Prayer requests  

---

### 🛠️ Planned Features _(Later)_
- **_Add, edit, and remove events from group calendars_**  
- **_Customizable accountability tracks_**  
- **_Accountability partners can collectively ping other partners who are not being held accountable properly_**  
- **_Customizable weekly plans_**  
- **_Document attachments to events_**  
- **_Location attachments to events_**  
- **_Picture sending in group chats_**  
- **_Real time group chat (type indicators, READ RECEIPTS)_**  
- **_Polls and quick surveys in group chats_**  
- **_Sync with external calendars_**  
- **_RSVP and attendance tracking for events_**  
- **_Recurring event patterns (daily, weekly, custom intervals)_**  
- **_Time-zone automatic conversion for event invites_**  
- **_Waiting lists and capacity limits for events_**  
- **_Exportable reports_**  
- **_Dark mode_**
- Application logs
- Hierarchical personal goals (annual, quarterly, weekly)
- Dark mode (later)
- Notifications for chats
- Prayer requests

### Development Roadmap for Uplifted Hybrid App
_NOTE! THE FOLLOWING MILESTONES ARE AI GENERATED AND ARE NOT A FINAL DRAFT. THESE ARE GOING TO BE USED TO GUIDE THE FINALIZED MILESTONES LIST_

Below is a structured set of milestones, deliverables, and next steps to guide your Uplifted project from concept through MVP and beyond.

---

#### High-Level Milestone Timeline

| Milestone                                 | Deliverables                                                                                              | Est. Duration | Dependencies           |
|-------------------------------------------|-----------------------------------------------------------------------------------------------------------|---------------|------------------------|
| Finalize Tech Stack & Hosting             | • Confirm .NET 9 MAUI Blazor Hybrid + EF Core<br>• Select hosting provider                                | 1 week        | —                      |
| Capture Functional Requirements           | • Epic & user story backlog<br>• Acceptance criteria                                                      | 1–2 weeks     | Finalize Tech Stack    |
| Model Data & DB Schema                    | • ERD diagram<br>• Supabase table definitions & policies<br>• Migration plan                              | 2 weeks       | Functional Requirements|
| Scaffold & Seed Supabase DB               | • Supabase project setup<br>• Initial seed data (roles, plans, demo users)                                 | 1 week        | Model Data & DB Schema |
| Code-First EF Core Context                | • EF Core models & `DbContext`<br>• Migrations folder                                                     | 1 week        | Scaffold & Seed DB     |
| CI/CD & DevOps Setup                      | • GitHub repo & branch strategy<br>• GitHub Actions for build & migrations                                | 1 week        | EF Core Context        |
| Design System & Base Components           | • Style guide (colors, typography)<br>• Razor/MAUI component library                                       | 2 weeks       | EF Core Context        |
| Authentication & Authorization            | • Supabase Auth integration<br>• Login/Sign-up UI<br>• Role-based guards                                 | 2 weeks       | CI/CD & Design System  |
| Core CRUD & Group Management              | • Profile CRUD<br>• Group creation/joining<br>• Member management                                         | 2 weeks       | Auth & Authorization   |
| Accountability Reports (MVP Scope)        | • Morning/evening report forms<br>• Storage & retrieval<br>• Simple dashboard                             | 3 weeks       | Core CRUD & Groups     |
| Basic Chat & Notifications                 | • Text-only chat feed<br>• Threaded replies<br>• @mentions<br>• Push/Realtime hooks                       | 3 weeks       | Core CRUD & Groups     |
| Dashboard & Analytics                     | • Streak counters<br>• Completion rate charts<br>• Trend insights skeleton                                | 3 weeks       | Reports & Chat         |
| MVP Polish & Testing                      | • E2E tests<br>• Accessibility audit<br>• Mobile validation                                                | 2 weeks       | Dashboard & Analytics  |
| Release & Feedback                         | • Deployment to staging/production<br>• In-app bug report flow<br>• User feedback collection               | 2 weeks       | MVP Polish & Testing   |

---

## Milestone Details & Next Steps

### 1. Finalize Tech Stack & Hosting

- Evaluate hosting options: Azure App Service, Supabase Edge, Vercel, Netlify.  
- Decide on SSL, custom domain, and environment promotion strategy.  

### 2. Capture Functional Requirements

- Break each core feature into epics and user stories.  
- Prioritize MVP stories and define acceptance criteria.  
- Document non-functional requirements such as performance and security.  

### 3. Model Data & DB Schema

- Draft an ERD with entities: User, Role, Group, Membership, Report, Message, Thread, Mention, Goal, Plan, Streak, Notification, Log, PrayerRequest.  
- Define relationships, soft deletes, and audit columns.  
- Plan RLS policies and migration strategy.  

### 4. Scaffold & Seed Supabase DB

- Create Supabase project via dashboard or CLI.  
- Write SQL for tables, RLS, and seed default records.  
- Store migration scripts in version control.  

### 5. Code-First EF Core Context

- Implement EF Core models using data annotations and fluent API.  
- Enable code-first migrations and validate generated SQL against Supabase.  
- Create initial migration and apply it.  

### 6. CI/CD & DevOps Setup

- Initialize GitHub repository with main/dev/feature branches.  
- Create GitHub Actions workflows to build, test, and apply migrations.  
- Store secrets (connection strings, SUPABASE_URL/KEY) in GitHub Secrets.  

### 7. Design System & Base Components

- Define theme: primary/secondary colors, spacing scale, typography.  
- Build shared Razor component library: Button, Input, Modal, Card, Toast, NavMenu.  
- Sync MAUI native styles with web theme.  

### 8. Authentication & Authorization

- Integrate Supabase Auth in MAUI and Blazor OR Create Personal Auth Service.
- Implement sign-up, login, and password reset flows.  
- Secure routes with `[Authorize]` and role-based guards.  

### 9. Core CRUD & Group Management

- Develop user profile page with edit capabilities.  
- Build group management UI: create, browse, join, invite, and remove members.  

### 10. Accountability Reports (MVP Scope)

- Create Razor forms for morning and evening check-ins.  
- Store and retrieve reports via injected `DbContext`.  
- Display recent reports in a feed with response actions.  

### 11. Basic Chat & Notifications

- Implement real-time text chat using Supabase Realtime.  
- Support threaded replies and @mention parsing.  
- Trigger in-app notifications via MAUI Essentials.  

### 12. Dashboard & Analytics

- Calculate streaks and completion rates via EF Core queries.  
- Integrate a Blazor chart library for visualizations.  
- Scaffold predictive insight messages.  

### 13. MVP Polish & Testing

- Author Playwright/E2E tests for core user flows.  
- Unit test EF Core queries and business logic.  
- Validate on iOS and Android simulators.  

### 14. Release & Feedback

- Deploy to production and staging environments.  
- Enable in-app bug reporting linked to GitHub Issues or a lightweight API.  
- Collect usage analytics and user feedback.  
