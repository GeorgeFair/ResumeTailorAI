## Overview
ResumeTailorAI is a simple web application that helps users tailor their resumes to specific job listings. Users paste their resume and a job description into two input boxes, and the app returns AI-generated suggestions in bullet point form. It uses OpenAI's API to analyze and compare the inputs.

## Features
- Paste-based input for resume and job description
- One-click analysis with AI-generated bullet point suggestions
- ASP.NET Razor Pages frontend
- Modular backend with services for parsing and OpenAI integration

## Project Structure

- **Controllers/**  
  - `ResumeController.cs`: Handles form submissions and passes data to the services

- **Services/**  
  - `OpenAiService.cs`: Sends input to OpenAI and returns tailored feedback
  - `ResumeParser.cs`: (Optional) Parses resume data if needed later

- **Views/Pages/**  
  - `Index.cshtml`: UI with two text boxes and a submit button

- **Models/**  
  - `ResumeAnalysisResult.cs`: Stores feedback and suggestions returned by the AI

- **wwwroot/**  
  - Static files (CSS/JS) for UI styling

- **Program.cs**  
  - Sets up the web host and configures services

- **appsettings.json**  
  - Stores configuration such as OpenAI API key

## Getting Started
1. Clone the repo
2. Add your OpenAI API key to `appsettings.json`
3. Run the app: `dotnet run`
4. Paste resume + job description → Get instant feedback


## Usage Guidelines
- Upload your resume through the main page.
- The application will analyze your resume and provide feedback and suggestions.
- Use the insights to tailor your resume for better job opportunities.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.