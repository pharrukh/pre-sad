mkdir LibraryApp.TEST
cd LibraryApp.TEST
ls
dotnet new nunit
dotnet sln LibraryApp.sln add LibraryApp.TEST/LibraryApp.TEST.csproj
dotnet add LibraryApp.TEST/LibraryApp.TEST.csproj reference LibraryApp.BLL/LibraryApp.BLL.csproj 
dotnet add LibraryApp.TEST/LibraryApp.TEST.csproj reference LibraryApp.DAL/LibraryApp.DAL.csproj
dotnet add LibraryApp.TEST/LibraryApp.TEST.csproj package moq
dotnet test LibraryApp.TEST/LibraryApp.TEST.csproj