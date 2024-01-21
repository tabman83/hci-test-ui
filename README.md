# hci-test-app

A demo web app for the HCI take home tech assessment.

[![Azure Static Web Apps CI/CD](https://github.com/tabman83/hci-test-ui/actions/workflows/azure-static-web-apps-icy-river-017fa1c03.yml/badge.svg?branch=master)](https://github.com/tabman83/hci-test-ui/actions/workflows/azure-static-web-apps-icy-river-017fa1c03.yml)

## Local dev

Clone this repo, then run the following to install the prerequisites:

```bash
npm install -g @azure/static-web-apps-cli
```

Login to Azure:
```bash
swa login
```

Then run the app:
```bash
swa start
```

and follow the on screen instructions. 
Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

## Deploying the app

The app is deployed by a CI/CD pipeline provided by Github Actions and it's served at the following URL:
https://icy-river-017fa1c03.4.azurestaticapps.net/

## Creating the app

The following prerequisites have been installed:
- [Node.js v. 20.11 LTS](https://nodejs.org/en/download)
- [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Cisolated-process%2Cnode-v4%2Cpython-v2%2Chttp-trigger%2Ccontainer-apps&pivots=programming-language-csharp#install-the-azure-functions-core-tools)

The webapp has been bootstrapped with Next.js:
- https://react.dev/learn/start-a-new-react-project
- https://learn.microsoft.com/en-us/azure/static-web-apps/deploy-nextjs-hybrid

The API (Azure Function) has been boostrapped with the following:
```
func init
func new 
```