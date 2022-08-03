# People Database Management | Relational Data Including City, Languages, Country.
Angular Fronted<br/>
Razor Pages Fronted also implemented<br/>
MVC Pattern<br/>
Entity Framework Core.<br/>
Entity Framework Core Identity.<br/>
Microsoft SQL Server.<br/>
Migrated from .Net Core 3.1 to .Net 6.<br/>
Requires Visual Studio 2022 for all options.<br/>
Able to be executed on Visual Studio 2019 (.Net Hosting SDK must be installed on your machine).<br/>

# Database Relations
A Person can have one or multiple languages<br/>
A language can have one or multiple persons<br/>
A city can have one or multiple persons<br/>
A person can have one and only one city<br/>
A city can have one & only one country<br/>
A country can have one or multiple cities<br/>

# Notes:
Both Web Api and Angular App run on same address

Tip: Your angular routes should be different from ASP.Net Web Api endpoints.(They can also be same)

If you want to match Angular routes with ASP.Net Web Api endpoints,
Consider following things:
1. So if you route to an address through Angular, it will show you webpage
2. and if you hit enter in address bar on that address, you will get ASP.Net Web Api's Json Body
2. So you can run them on separate adresses
and for that, your ASP.Net project should have following code in Startup.cs file

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
 before
            app.UseHttpsRedirection();

