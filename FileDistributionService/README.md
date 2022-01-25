# FileDistributionService

### Steps for successful run
1. Clone the repo to your local computer
2. Open Visual Studio or an IDE of your choice 
3. In appsettings.json in ConnectionStrings in DefaultConnection enter your desired server name where the db will be hosted
4. Through the Package Manager Console run:
* Add-Migration Initial
* Update-Database
5. Once the database has been created you can start the project
6. A swagger UI will open and first we have to authenticate to the app so we can get a token
7. Call [POST] /api/Account/GetToken with username and password from the file AccountsController.cs. You can also use "admin", "admin" as default
8. After executing, copy the token from the response and insert it in the top right corner of the swagger page where it says "Authorize"
* If you are using Postman, Insomnia or a similar tool, you will have to put the token in the Authorization header
9. Now you can call the /api/Updates/GetAvailableUpdates [GET] call
