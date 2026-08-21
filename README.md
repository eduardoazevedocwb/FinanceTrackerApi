# FinanceTracker — Project Overview

**Intention:** FinanceTracker is a personal finance management API built to demonstrate modern .NET engineering practices end-to-end — from domain modeling to distributed-systems concerns. It doubles as a living reference for the team, showing how DDD, clean architecture, and cloud-native patterns fit together in a real, non-trivial codebase.

---

## 1. Core / Already Implemented

| Category | Technology / Practice |
|---|---|
| Runtime | .NET 8 (LTS) |
| Data Access | Entity Framework Core (Code-First, migrations) |
| Architecture | Domain-Driven Design (DDD) — Entities, Value Objects, Aggregates, Domain Events |
| Layering | Clean Architecture (Domain / Application / Infrastructure / API) |
| Application Layer | CQRS with MediatR (Commands, Queries, Handlers) |
| Object Mapping | AutoMapper |
| Validation | FluentValidation |
| Dependency Management | Dependency Injection (built-in .NET DI container) |
| Data Access Pattern | Repository + Unit of Work |
| API Documentation | Swagger / OpenAPI |
| Authentication | JWT Bearer authentication, role-based authorization |
| Logging | Serilog (structured logging, sinks) |
| Testing | xUnit + Moq (unit tests for domain and application layers) |
| API Style | RESTful Web API, versioned endpoints |
| Error Handling | Global exception middleware, Result/Either pattern |
