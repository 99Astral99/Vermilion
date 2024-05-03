# Vermilion

# Purpose
- For easy search of cafes and restaurants in the city of Mariupol 
- An explicit demonstration of the DDD architecture
  
- Vermilion - project name
- MVP - minumum viable product

# Stack
- .NET 8 WebApi
- Entity Framework Core 8
- MediatR + CQRS
- Serilog
- PostgreSQL
- MinIO
- Docker
- Redis
- RabbitMQ + MassTransit
- xUnit, Moq

# Features
- FluentValidation
- FluentResults
- Ardalis.Guard
- Ardalis.Specification

# Application functionality

## Auth
- Based on permissions (i'll update this section later)

## User
- Create (mvp) ❌
- Get (mvp)❌
- Update ❌
- Delete ❌
- Add Review ❌
- Create Restaurant❌
- Upload Restaurant image ❌

## Catering
- Create (mvp) ✔️
- Get (mvp)✔️
- Update ✔️
- Delete ✔️
- Restaurant pagination ✔️

## Menu
- Create (mvp) ❌
- Get (mvp)❌
- Update ❌
- Delete ❌

## Catering Cuisine 
- Create (mvp) ✔️
- Get (mvp)❌
- Update ❌
- Delete ❌
- Filter by cuisines ❌

## Catering Feature
- Create (mvp) ✔️
- Get (mvp)❌
- Update ❌
- Delete ❌
- Filter by features ❌

## Catering opening hours (Work Schedule)
- Create (mvp) ❌
- Get (mvp)❌
- Update ❌
- Delete ❌
