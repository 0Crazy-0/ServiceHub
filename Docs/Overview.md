# ServiceHub - Project Overview

## Introduction
ServiceHub is a production-ready, containerized full-stack architecture featuring an **ASP.NET Core Backend**, **Astro SSR**, and **PostgreSQL**. This template is designed for scalability, maintainability, and ease of deployment using Docker Compose. It leverages a robust microservices-ready architecture to facilitate service management and user interaction.

## Live Demo
You can view the live application deployed on Render here: [ServiceHub Live Demo](https://servicehub-esd7.onrender.com/)

## Architecture

The project follows a decoupled client-server architecture, containerized using Docker for consistent deployment across environments.

### Technology Stack

*   **Backend**: ASP.NET Core (.NET 8/9)
    *   Implements a **layered architecture** for clean separation of concerns.
    *   Provides RESTful endpoints for the frontend.
    *   Handles business logic, authentication, and data persistence.
    *   Uses Entity Framework Core for ORM.
*   **Frontend**: Astro (Node.js)
    *   Delivers a fast, server-side rendered (SSR) user interface.
    *   Styled with TailwindCSS for a modern, responsive design.
    *   Consumes the backend API for dynamic content.
*   **Database**: PostgreSQL 16
    *   Relational database management system for persistent storage.
    *   Running in a Docker container.
*   **Containerization**: Docker & Docker Compose
    *   Orchestrates the multi-containe rapplication (Backend, Frontend, Database).

## Key Features

*   **User Authentication**: Secure login and registration using JWT (JSON Web Tokens) and Google OAuth integration.
*   **Service Management**: Comprehensive CRUD operations for managing services.
*   **Responsive UI**: A mobile-first, responsive user interface built with modern web standards.
*   **Scalability**: Designed with separation of concerns to allow independent scaling of frontend and backend components.
