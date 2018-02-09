# ASP.NET Core WishList Application

The ASP.NET Core WishList Application is designed to allow users to create their own wishlists, and other users to mark that they are buying those items in such a way the owner of the wish list isn't able to see, while other users are able to see. This application is designed using the Model View Controller design pattern.

# Setup the Application

## If you want to use Visual Studio
If you want to use Visual Studio (highly recommended for Windows users) follow the following steps:
-	If you already have Visual Studio installed make sure you have .Net Core installed by running the "Visual Studio Installer" and making sure both "ASP.NET" and ".NET Core cross-platform development" are checked
-	If you need to install visual studio download it at https://www.microsoft.com/net/core#windowsvs2017 On the workloads screen make sure ".NET Core cross-platform development" is checked
-	To run the application simply press the Start Debug button (green arrow) or press F5
-	To run the tests go to "Test" and select "Run All Tests" (you might need to goto "Test" > "Windows" > "Test Explorer" to display the results if you closed the test explorer.)

## If you don't plan to use Visual studio
If you would rather use something other than Visual Studio
-	Install the .Net Core SDK from https://www.microsoft.com/net/download/core once that installation completes you're ready to roll!
-	To run the application go into the WishList project folder and type `dotnet run`
-	To run the tests go into the WishListTests project folder and type `dotnet test /verbosity:quiet` (for OSX users use `dotnet test --verbosity:quiet` instead)

# Project Goals

- Create the ability for users to create a wishlist
- Create the ability for other users to view and mark items as purchased on the wish list
- Create the ability to remove items from your wishlist

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

- [ ] Creating ASP.NET Core Application from scratch
	- [ ] Add Middleware/Configuration to Startup.cs
		- [ ] Add Static File support
			- Add UseStaticFiles to Configure.
		- [ ] Add MVC support
			- Add AddMVC to ConfigureServices.
			- Add UseMVC to Configure.
				- Provide UseMVC with default Controller/Action/Id Route (defaulting to Home/Index)
		- [ ] Add EntityFramework support
			- Add DbContext to ConfigureServices.
			- Set to use Local SqlLite database
				- InMemory when running in testing / dev ?
		- [ ] Add Authentication support
			- Add AddIdentity to ConfigureServices.
				- Use EntityFrameworkStorers
				- Use DefaultTokenProviders
			- Add UseAuthentication to Configure.
		- [ ] Setup Error Pages
			- Add IsDevelopment Condition to Configure
				- If Development add UseBrowserLink, UseDeveloperExceptionPage, and UseDatabaseErrorPage
				- If Not Development Add UseExceptionHandler and point it to Home/Error.cshtml
		- [ ] Setup Development Envirornment
			- Add envirornment type to launchsettings.json or WishList.csproj
	- [ ] Add HomeController and Views
		- [ ] Add Generic Welcome View
			- Create a new Folder "Home" in the "Views" folder
			- Create a new View "Index" in the "Home" folder
				- This view should simply welcome the user to the WishList Application.
		- [ ] Add Error View
			- Create a new Folder "Views"
			- Create a new Folder "Shared" in the "Views" folder
			- Create a new View in the Shared Folder named "Error"
				- This view should simply say "An Error has occurred. Please Try again."
		- [ ] Create HomeController
			- Create a new Folder "Controllers"
			- Create a new Controller "HomeController" inside the "Controllers" folder
			- Create a new Action "Index" in the HomeController
				- This action should return an ActionResult
				- The return statement should be a View
			- Create a new Action "Error" in the HomeController
				- This action should return an ActionResult
				- The return statement should be a View
	- [ ] Setup Basic Authentication
		- [ ] Create "RegisterViewModel"
		
			
