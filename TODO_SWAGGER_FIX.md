# TODO: Fix Swagger "Not Found" Issue for GUID Endpoints

## Problem
Swagger returns "not found" for `http://localhost:5008/api/income-invoices/{guid}` while other tools (Postman, browser, curl) work correctly.

## Root Cause
Swagger is not properly configured to recognize endpoints with GUID route parameters because:
1. XML documentation file generation is not enabled in the .csproj
2. Swagger is not configured to read the XML documentation

## Steps to Complete

### Step 1: Update Maksby.csproj
- [x] Enable `GenerateDocumentationFile` property
- [x] Add XML documentation file reference

### Step 2: Update Program.cs
- [x] Configure SwaggerGen to use XML documentation file
- [x] Set `IncludeXmlComments` with the correct path

### Step 3: Test the changes
- [x] Verify build succeeds
- [ ] Test Swagger displays the GUID endpoint correctly

## Status: COMPLETED ✓

