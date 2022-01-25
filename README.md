# FileDistributionService

### Steps for successful run
1. Clone the repo to your local computer
2. Open Visual Studio or an IDE of your choice 
3. In FileDistributionService\appsettings.json in ConnectionStrings in DefaultConnection enter your desired server name where the db will be hosted
4. Through the Package Manager Console run:
* Add-Migration Initial
* Update-Database
5. Once the database has been created you can start the back end API project
6. From Visual Studio Code or from command prompt navigate to "file-distribution-service-ui/" folder and run "npm i"
7. in appsettings.json change the value of apiLoginEndpoint key to your API endpoint. For example "https://localhost:7040/api/" 
8. Then run "npm start"
9. The front end app will open in your default broswer
10. Login with username and password from the file FileDistributionService/Controllers/AccountController.cs. You can also use "admin", "admin" as default
11. Now you can use the app
