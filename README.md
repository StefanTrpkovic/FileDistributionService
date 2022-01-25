# FileDistributionService

### Steps for successful run
1. Clone the repo to your local computer
2. Open Visual Studio or an IDE of your choice 
3. In FileDistributionService\FileDistributionService\appsettings.json in ConnectionStrings in DefaultConnection enter your desired server name where the db will be hosted
4. In Solution Explorer set your main project to be FileDistributionService
5. In the Package Manager Console choose the  default project to be Persistence 
6. In the Package Manager run:
* Add-Migration Initial
* Update-Database
7. Once the database has been created you can start the back end API project
8. From Visual Studio Code or from command prompt navigate to "file-distribution-service-ui/" folder and run "npm i"
9. in appsettings.json change the value of apiLoginEndpoint key to your API endpoint. For example "https://localhost:7040/api/" 
10. Then run "npm start"
11. The front end app will open in your default broswer
12. Login with username and password from the file FileDistributionService/Controllers/AccountController.cs. You can also use "admin", "admin" as default
13. Now you can use the app
