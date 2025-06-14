docker run --name mysql-db -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=MyAppDb -p 3306:3306 -d mysql:8.0

dotnet aspnet-codegenerator controller -name PoliciesController -m Policy -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name ClientsController -m Client -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name BranchesController -m Branch -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name EmployeeController -m Employee -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name InsuranceCaseController -m InsuranceCase -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
dotnet aspnet-codegenerator controller -name PayoutController -m Payout -dc AppDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

dotnet tool install --global dotnet-aspnet-codegenerator

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0

dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet watch run
