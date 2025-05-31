# ResumeTailorAI

## Overview
ResumeTailorAI is a web application designed to assist users in tailoring their resumes using advanced parsing and analysis techniques. The application leverages OpenAI's API to provide suggestions and feedback on resumes.

## Project Structure
The project is organized into several key folders and files:

- **Controllers/**: Contains the `ResumeController.cs` which handles HTTP requests related to resumes.
- **Services/**: 
  - `ResumeParser.cs`: Contains methods for parsing and validating resume data.
  - `OpenAiService.cs`: Interacts with OpenAI's API to generate suggestions and analysis results.
- **Views/Pages/**: 
  - `Index.cshtml`: The main page of the application for uploading and analyzing resumes.
- **Models/**: 
  - `ResumeAnalysisResult.cs`: Represents the result of a resume analysis, including score, feedback, and suggestions.
- **wwwroot/**: Contains static files such as CSS and JavaScript for styling and functionality.
- **Program.cs**: The entry point of the application, setting up the web host and configuring services.
- **appsettings.json**: Configuration settings for the application, including API keys.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd ResumeTailorAI
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run
   ```

## Usage Guidelines
- Upload your resume through the main page.
- The application will analyze your resume and provide feedback and suggestions.
- Use the insights to tailor your resume for better job opportunities.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.