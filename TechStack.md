# Uplifted Tech Stack
This document lists all of the high level architecture items within the technology stack of the Uplifted application.

# Layers
1. Database Layer
2. Data Access Layer
3. Business Logic Layer
4. API/Application Layer
5. Presentation Layer (UI)
6. Application Monitoring Layer (Logging)
7. DevOps Layer

## 1. Database Layer
Supabase (PostgreSQL)

## 2. Data Access Layer
.NET 9 + Entity Framework Core

## 3. Business Logic Layer
.NET 9 service classes

## 4. API/Application Layer
.NET 9 MVC API

## 5. Presentation Layer (UI)
.NET 9 MAUI Blazor Hybrid

## 6. Application Monitoring Layer (Logging)
Personal Logging Service

## 7. DevOps Layer
GitHub Actions

# Hosting
We will have a development and production host.

- Database:
  - Dev: Supabase Free
  - Prod: Supabase Free/Pro ($25/month)

- Data Access and Business Logic:
  - Bundled into API at runtime for both Dev and Prod
 
- API/Application Layer:
  - Dev: Run Locally
  - Prod: NOT SURE YET! Trying to find something cheap/free
 
- Presentation Layer (UI)
  - Dev: Run Locally
  - Prod: GitHub pages
 
- Presentation Layer Mobile (UI):
  - Dev: GitHub actions for builds -> artifacts in GitHub Releases
  - Prod: GitHub Actions builds -> distribute IPA/APK via GitHub Releases or integrate with App Store/Play Store pipelines

- DevOps Layer:
  - GtHub Actions
