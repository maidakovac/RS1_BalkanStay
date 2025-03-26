# Balkan Stay - Apartment Reservation System

## Overview
This project is an **Angular** application for searching and booking apartments on the Balkans. Users can explore available apartments, check their details, filter results, and make reservations. The system includes authentication, reservation management, and an integrated search functionality.

## Features
- **Apartment Search & Filtering**: Users can search apartments by location, price, and amenities.
- **Reservation System**: Users can make reservations, and the system retrieves occupied dates to prevent double booking.
- **Authentication & Security**: Users can create profiles and log in securely. The system includes **two-factor authentication (2FA)** to enhance security and protect user accounts.
- **Backend Integration**: Fetches data via API.

## Technologies Used
- **Frontend**: Angular, TypeScript, HTML, SCSS
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server
- **Hosting & DevOps**: Azure DevOps, GitHub

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/maidakovac/RS1_BalkanStay.git
   cd RS1_BalkanStay
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Run the development server:
   ```bash
   ng serve
   ```
4. Open the app in your browser: `http://localhost:4200`

## API Configuration
Ensure your backend API is running and update `environment.ts` with the correct API URL:
```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:8000/api'
};
```

## Deployment
- The project supports **CI/CD via Azure DevOps**, with automated deployments configured for the frontend and backend.
- To deploy manually:
  ```bash
  ng build --prod
  ```
  Deploy the `dist/` folder to the hosting service.

## Contribution
Feel free to fork this repository, submit issues, or make pull requests to improve the system.

## License
This project is licensed under the MIT License.
