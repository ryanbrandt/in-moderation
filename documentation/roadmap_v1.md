# Road Map V1

Simple proof of concept app, below covers the roadmap for the initally planned features

## Backend

`ASP.NET` REST API

- [ x ] Configure project (packages, frameworks)
- [ x ] Initial migrations
  - user
  - site
  - site_rule
- [ ] Initial endpoints
  - Swagger doc
  - CRUD site_rule
  - CR site
- [ ] Deployment
  - AWS EC2 if its included in free tier, else heroku
- [ ] Clean up sites with no rules
  - Cron job

## Frontend

- [ ] Configure project (packages, frameworks)
- [ ] Login flow
  - Login screen
  - Business logic, preference towards requiring login with Google account
- [ ] Create new site rule flow
  - UI/Form
  - Business logic
- [ ] Edit existing site rule flow
  - UI/Form
  - Business logic
- [ ] Deployment to chrome plugin store
