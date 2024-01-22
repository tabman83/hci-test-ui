# HCI Test App

![Azure Static Web Apps CI/CD](https://github.com/tabman83/hci-test-ui/actions/workflows/azure-static-web-apps-icy-river-017fa1c03.yml/badge.svg?branch=master)

## Overview

HCI Test App is a web application designed as part of the HCI take-home tech assessment. It showcases a patient management system, allowing users to search for a patient, view patient details, and list their visits. The front-end is built with Next.js, a React framework, while the backend leverages Azure Functions to handle API requests. The app is hosted on Azure Static Web Apps.

## Features

- **Patient Search**: Users can search for a patient by their name.
- **Patient Details**: Displays detailed information of a patient.
- **Visit Listings**: Lists all the visits for a particular patient, including the consultant's name and appointment date/time.

## Local Development Setup

### Prerequisites

Before setting up the project locally, ensure you have the following installed:
- [Node.js v. 20.11 LTS](https://nodejs.org/en/download)
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Cisolated-process%2Cnode-v4%2Cpython-v2%2Chttp-trigger%2Ccontainer-apps&pivots=programming-language-csharp#install-the-azure-functions-core-tools)

### Installation

1. **Clone the Repository:**
   
Start by cloning the repository to your local machine.

```bash
git clone https://github.com/tabman83/hci-test-ui.git
cd hci-test-ui
```

2. **Install Dependencies:**

Install the necessary npm packages for the project.

```bash
npm install
npm install -g @azure/static-web-apps-cli
```

3. **Local Azure Login:**

Authenticate the Static Web Apps CLI with Azure to allow local resource interaction.

```bash
swa login
```

4. **Running the Application:**

Launch the application locally using the Azure Static Web Apps CLI.

```bash
swa start
```

Follow the on-screen instructions. The application will be available at http://localhost:3000.

### Deployment
The application is automatically deployed via a CI/CD pipeline set up in GitHub Actions.

URL: [https://icy-river-017fa1c03.4.azurestaticapps.net/](https://icy-river-017fa1c03.4.azurestaticapps.net/)
Any push to the master branch triggers the pipeline, building the app, running tests, and deploying it to Azure Static Web Apps.

### Application Structure

#### Frontend (Next.js)
The frontend is bootstrapped with Next.js, providing server-side rendering and static site generation capabilities.

Starting a New React Project (Next.js):
[React Documentation](https://react.dev/learn/start-a-new-react-project)
[Deploy Next.js on Azure Static Web Apps](https://learn.microsoft.com/en-us/azure/static-web-apps/deploy-nextjs-hybrid)

#### Backend (Azure Function)
The backend API is an Azure Function, responsible for handling patient data requests.

Initialization & Setup:
```bash
func init
func new 
```

This sets up the function app project with the necessary configurations.

### Testing
Unit tests are integral to the project, ensuring code quality and functionality. They are automatically executed in the CI/CD pipeline. Ensure tests pass locally before pushing:
```bash
npm test
```