# Week 08 of Software Engineering Practice 2021
This is week 08 of the Software Engineering Practice. For this week, following tasks are completed:


**Implement exception handling and logging:**
- Add Exceptionless or ELMAH to the dotnetcore application.
- Configure error emails to go to a folder (instead of sending to an email).
	+ Later we can configure the same logs to go to an email when we setup SMTP server.
- Error logs must be stored in the database.

**Implementing Exceptionless:**
- Decided to add Exceptionless to the application for logging because:
	+ it has more features
	+ is is open-source
- We can self host Exceptionles, it requires following things:
	+ Install Elastic Search.
	+ Configure app behind IIS.
- Or we can use a free hosted service:
	+ Goto https://be.exceptionless.io/
	+ Signup for Free service.
	+ Select `ASP.NET Core` as project type.
	+ Install NuGet packages `Install-Package Exceptionless.AspNetCore`.
	+ Import Exceptionless with your API_KEY in app startup `app.UseExceptionless(API_KEY)`
		- This automatically sends unhandled exceptions to Exceptionless hosted service.
	+ To send exceptions manually:
		- Use `ex.ToExceptionless().Submit()`
