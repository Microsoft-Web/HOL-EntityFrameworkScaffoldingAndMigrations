<a name="HOLTop" />

# ASP.NET MVC 4 Entity Framework Scaffolding and Migrations #
---

<a name="Overview" />
## Overview ##

If you are familiar with ASP.NET MVC 4 controller methods, or have completed the "Helpers, Forms and Validation" Hands-On lab, you should be aware that many of the logic to create, update, list and remove any data entity it is repeated among the application. Not to mention that, if your model has several classes to manipulate, you will be likely to spend a considerable time writing the POST and GET action methods for each entity operation, as well as each of the views.

In this lab you will learn how to use the ASP.NET MVC 4 scaffolding to automatically generate the baseline of your application's CRUD (Create, Read, Update and Delete). Starting from a simple model class, and, without writing a single line of code, you will create a controller that will contain all the CRUD operations, as well as the all the necessary views. After building and running the simple solution, you will have the application database generated, together with the MVC logic and views for data manipulation.

In addition, you will learn how easy it is to use Entity Framework Migrations to perform model updates throughout your entire application. Entity Framework Migrations will let you modify your database after the model has changed with simple steps. With all these in mind, you will be able to build and maintain web applications more efficiently, taking advantage of the latest features of ASP.NET MVC 4.

<a name="Objectives" />
### Objectives ###

In this Hands-On Lab, you will learn how to:

- Use ASP.NET scaffolding for CRUD operations in controllers.
- Change the database model using Entity Framework Migrations.

<a name="Prerequisites" />
### Prerequisites ###

You must have the following items to complete this lab:

- [Microsoft Visual Studio Express 2012 for Web](http://www.microsoft.com/visualstudio/eng/products/visual-studio-express-for-web) or superior (read [Appendix A](#AppendixA) for instructions on how to install it).

<a name="Setup" /> 
### Setup ###

**Installing Code Snippets**

For convenience, much of the code you will be managing along this lab is available as Visual Studio code snippets. To install the code snippets run **.\Source\Assets\CodeSnippets.vsi** file.

If you are not familiar with the Visual Studio Code Snippets, and want to learn how to use them, you can refer to the appendix from this document "[Appendix C: Using Code Snippets](#AppendixC)".

---

<a name="Exercises" />
## Exercises ##
The following exercises make up this Hands-On Lab:

1. [Using ASP.NET MVC 4 Scaffolding with Entity Framework Migrations](#Exercise1)

> **Note:** This exercise is accompanied by an **End** folder containing the resulting solution you should obtain after completing the exercise. You can use this solution as a guide if you need additional help working through the exercise.

Estimated time to complete this lab: **30 minutes**

<a name="Exercise1" />
### Exercise 1: Using ASP.NET MVC 4 Scaffolding with Entity Framework Migrations###

ASP.NET MVC scaffolding provides a quick way to generate the CRUD operations in a standardized way, creating the necessary logic that lets your application interact with the database layer.

In this exercise, you will learn how to use MVC 4 scaffolding with code first to create the CRUD methods. 
Then, you will learn how to update your model applying the changes in the database by using Entity Framework Migrations.

<a name="Ex1Task1" />
####Task 1- Creating a new ASP.NET MVC 4 project using Scaffolding####

1. If not already open, start **Visual Studio 2012**.

1. Select **File | New Project**. In the New Project dialog, under the **Visual C# | Web** section, select **ASP.NET MVC 4 Web Application**. Name the project to **MVC4andEFMigrations** and set the location to **Source\Ex1-UsingMVC4ScaffoldingEFMigrations\** folder of this lab. Set the **Solution name** to **Begin** and ensure **Create directory for solution** is checked. Click **OK**.

 	![New ASP.NET MVC 4 Project Dialog Box](./images/add-new-mvc-project.png?raw=true "New ASP.NET MVC 4 Project Dialog Box")
 
	_New ASP.NET MVC 4 Project Dialog Box_

1. In the **New ASP.NET MVC 4 Project** dialog box select the **Internet Application** template, and make sure that **Razor** is the selected **View engine**. Click **OK** to create the project.

	 ![New ASP.NET MVC 4 Internet Application](./images/add-new-mvc-project-internet-app.png?raw=true "New ASP.NET MVC 4 Internet Application")

	_New ASP.NET MVC 4 Internet Application_

1. In the Solution Explorer, right-click **Models** and select **Add | Class** to create a simple class person (POCO). Name it **Person** and click **OK**.

1. Open the Person class and insert the following properties.

	(Code Snippet - _ASP.NET MVC 4 and Entity Framework Migrations - Ex1 Person Properties_)
	
	<!-- mark:10-14 -->
	````C#
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	namespace MVC4EF.Models
	{
		public class Person
		{
			public int PersonID { get; set; }

			public string FirstName { get; set; }

			public string LastName { get; set; }        
		}
	}
	````

1. Click **Build | Build Solution** to save the changes and build the project.

	![Building the application](images/visual-studio-build-application.png?raw=true "Building the application")

	_Building the Application_

1. In the Solution Explorer, right-click the controllers folder and select **Add | Controller**. 

1. Name the controller _PersonController_ and complete the **Scaffolding options** with the following values.	
	- In the **Template** drop-down list, select the **MVC controller with read/write actions and views, using Entity Framework** option.
	- In the **Model class** drop-down list, select the **Person** class.
	- In the **Data Context class** list, select **\<New data context...\>**. Choose any name and click **OK**.
	- In the **Views** drop-down list, make sure that **Razor** is selected.

	![Adding the Person controller with scaffolding](images/add-person-controller.png?raw=true "Adding the Person controller with scaffolding")

	_Adding the Person controller with scaffolding_
	
1. Click **Add** to create the new controller for Person with scaffolding. You have now generated the controller actions as well as the views. 
		
	![After creating the Person controller with scaffolding ](images/person-scaffolding.png?raw=true "After creating the Person controller with scaffolding")

	_After creating the Person controller with scaffolding_

1. Open **PersonController** class. Notice that the full CRUD action methods have been generated automatically. 

	![Inside the Person controller](images/person-controller-code.png?raw=true "Inside the Person controller")

	_Inside the Person controller_

<a name="Ex1Task2" />
####Task 2- Running the application ####
	
At this point, the database is not yet created. In this task, you will run the application for the first time and test the CRUD operations. The database will be created on the fly with Code First.

1. Press **F5** to run the application.

1. In the browser, add **/Person** to the URL to open the Person page. 

	![Application first run](images/application-first-run.png?raw=true "Application first run")

	_Application: first run_

	
1. You will now explore the Person pages and test the CRUD operations.

	1. Click **Create New** to add a new person. Enter a first name and a last name and click **Create**.

		![Adding a new person](images/adding-a-new-person.png?raw=true "Adding a new person")

		_Adding a new person_

	1. In the person's list, you can delete, edit or add items.

		![person list](images/person-list.png?raw=true "person list")

		_Person list_

	1. Click **Details** to open the person's details.

		![Person's details](images/person-details.png?raw=true "Person's details")

		_Person's details_

1. Close the browser and return to Visual Studio.
Notice that you have created the whole CRUD for the person entity throughout your application -from the model to the views- without having to write a single line of code!

<a name="Ex1Task3" />
####Task 3- Updating the database using Entity Framework Migrations#

In this task you will update the database using Entity Framework Migrations. You will discover how easy it is to change the model and reflect the changes in your databases by using the Entity Framework Migrations feature.

1. Open the Package Manager Console. Select **Tools | Library Package Manager | Package Manager Console**.

1. In the Package Manager Console, enter the following command:

	<!-- mark:1 -->
	````PMC
	Enable-Migrations -ContextTypeName [ContextClassName]
	````

	![Enabling Migrations](images/PMC-enable-migrations.png?raw=true "Enabling Migrations")

	_Enabling migrations_

	The Enable-Migration command creates the **Migrations** folder, which contains a script to initialize the database.

	![Migrations folder](images/migrations-folder.png?raw=true "Migrations folder")

	_Migrations folder_

1. Open the **Configuration.cs** file in the Migrations folder. Locate the class constructor and change the **AutomaticMigrationsEnabled** value to _true_.

	<!-- mark:3 -->
	````C#
	public Configuration()
   {
		AutomaticMigrationsEnabled = true;
   }
	````

1. Open the Person class and add an attribute for the person's middle name. With this new attribute, you are changing the model.

	<!-- mark:9 -->
	````C#
	public class Person
	{
		public int PersonID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
		
		public string MiddleName { get; set; }
	}
	````

1. Select **Build | Build Solution** on the menu to build the application.

	![Building the application](images/visual-studio-build-application2.png?raw=true "Building the application")

	_Building the application_

1. In the Package Manager Console, enter the following command:

	<!-- mark:1 -->
	````PMC
	Add-Migration AddMiddleName
	````
	
	This command will look for changes in the data objects, and then, it will add the necessary commands to modify the database accordingly.

	![Adding a middle name](images/PMC-adding-middle-name.png?raw=true "Adding a middle name")

	_Adding a middle name_

1. (Optional) You can run the following command to generate a SQL script with the differential update. This will let you update the database manually (In this case it's not necessary), or apply the changes in other databases:

	<!-- mark:1 -->
	````PMC
	Update-Database -Script -SourceMigration:$InitialDatabase
	````

	![Generating a SQL script](images/PMC-generating-a-sql-script.png?raw=true "Generating a SQL script")

	_Generating a SQL script_

	![SQL Script update](images/sql-script-update.png?raw=true "SQL Script update")

	_SQL Script update_

1. In the Package Manager Console, enter the following command to update the database:

	<!-- mark:1 -->
	````PMC
	Update-Database -Verbose
	````

	![Updating the Database](images/PMC-updating-the-database.png?raw=true "Updating the Database")

	_Updating the Database_

	This will add the **MiddleName** column in the **People** table to match the current definition of the **Person** class.

1. Once the database is updated, right-click the Controller folder and select **Add | Controller** to add the Person controller again (Complete with the same values). This will update the existing methods and views adding the new attribute.

	![Adding a controller update](images/adding-a-controller-update.png?raw=true "Adding a controller update")

	_Updating the controller_

1. Click **Add**. Then, select the values **Overwrite PersonController.cs** and the **Overwrite associated views** and click **OK**.

	![Adding a controller overwrite](images/adding-a-controller-overwrite.png?raw=true)

	_Updating the controller_


<a name="Ex1Task4" />
#### Task4- Running the application ####

1. Press **F5** to run the application.

1. Open **/Person**. Notice that the data was preserved, while the middle name column was added.

	![Middle Name added](images/middle-name-added.png?raw=true "Middle Name added")

	_Middle Name added_

1. If you click **Edit**, you will be able to add a middle name to the current person.

	![Middle Name edition](images/middle-name-edition.png?raw=true "Middle Name edition")

	
>**Note:** Additionally, you can deploy this application to Windows Azure Web Sites following [Appendix B: Publishing an ASP.NET MVC 4 Application using Web Deploy](#AppendixB).

---

<a name="Summary" />
## Summary ##

In this Hands-On lab, you have learned simple steps to create CRUD operations with ASP.NET MVC 4 Scaffolding using any model class. Then, you have learned how to perform an end to end update in your application -from the database to the views- by using Entity Framework Migrations.


<a name="AppendixA" />
## Appendix A: Installing Visual Studio Express 2012 for Web ##

You can install **Microsoft Visual Studio Express 2012 for Web** or another "Express" version using the **[Microsoft Web Platform Installer](http://www.microsoft.com/web/downloads/platform.aspx)**. The following instructions guide you through the steps required to install _Visual studio Express 2012 for Web_ using _Microsoft Web Platform Installer_.

1. Go to [http://go.microsoft.com/?linkid=9810169](http://go.microsoft.com/?linkid=9810169). Alternatively, if you already have installed Web Platform Installer, you can open it and search for the product "_Visual Studio Express 2012 for Web with Windows Azure SDK_".

1. Click on **Install Now**. If you do not have **Web Platform Installer** you will be redirected to download and install it first.

1. Once **Web Platform Installer** is open, click **Install** to start the setup.

	![Install Visual Studio Express](images/install-visual-studio-express.png?raw=true "Install Visual Studio Express")

 	_Install Visual Studio Express_

1. Read all the products' licenses and terms and click **I Accept** to continue.

	![Accepting the license terms](images/accepting-the-license-terms.png?raw=true)

	_Accepting the license terms_

1. Wait until the downloading and installation process completes.

	![Installation progress](images/installation-progress.png?raw=true)

	_Installation progress_

1. When the installation completes, click **Finish**.

	![Installation completed](images/installation-completed.png?raw=true)

	_Installation completed_

1. Click **Exit** to close Web Platform Installer.

1. To open Visual Studio Express for Web, go to the **Start** screen and start writing "**VS Express**", then click on the **VS Express for Web** tile.

	![VS Express for Web tile](images/vs-express-for-web-tile.png?raw=true)

	_VS Express for Web tile_

<a name="AppendixB" />
## Appendix B: Publishing an ASP.NET MVC 4 Application using Web Deploy ##

This appendix will show you how to create a new web site from the Windows Azure Management Portal and publish the application you obtained by following the lab, taking advantage of the Web Deploy publishing feature provided by Windows Azure.

<a name="ApxBTask1"></a>
#### Task 1 – Creating a New Web Site from the Windows Azure Portal ####

1. Go to the [Windows Azure Management Portal](https://manage.windowsazure.com/) and sign in using the Microsoft credentials associated with your subscription.

	![Log on to Windows Azure portal](images/login.png?raw=true "Log on to Windows Azure portal")

	_Log on to Windows Azure Management Portal_

1. Click **New** on the command bar.

	![Creating a new Web Site](images/new-website.png?raw=true "Creating a new Web Site")

	_Creating a new Web Site_

1. Click **Compute** | **Web Site**. Then select **Quick Create** option. Provide an available URL for the new web site and click **Create Web Site**.

	> **Note:** A Windows Azure Web Site is the host for a web application running in the cloud that you can control and manage. The Quick Create option allows you to deploy a completed web application to the Windows Azure Web Site from outside the portal. It does not include steps for setting up a database.

	![Creating a new Web Site using Quick Create](images/quick-create.png?raw=true "Creating a new Web Site using Quick Create")

	_Creating a new Web Site using Quick Create_

1. Wait until the new **Web Site** is created.

1. Once the Web Site is created click the link under the **URL** column. Check that the new Web Site is working.

	![Browsing to the new web site](images/navigate-website.png?raw=true "Browsing to the new web site")

	_Browsing to the new web site_

	![Web site running](images/website-working.png?raw=true "Web site running")

	_Web site running_

1. Go back to the portal and click the name of the web site under the **Name** column to display the management pages.

	![Opening the web site management pages](images/go-to-the-dashboard.png?raw=true "Opening the web site management pages")
	
	_Opening the Web Site management pages_

1. In the **Dashboard** page, under the **quick glance** section, click the **Download publish profile** link.

	> **Note:** The _publish profile_ contains all of the information required to publish a web application to a Windows Azure website for each enabled publication method. The publish profile contains the URLs, user credentials and database strings required to connect to and authenticate against each of the endpoints for which a publication method is enabled. **Microsoft WebMatrix 2**, **Microsoft Visual Studio Express for Web** and **Microsoft Visual Studio 2012** support reading publish profiles to automate configuration of these programs for publishing web applications to Windows Azure websites. 

	![Downloading the web site publish profile](images/download-publish-profile.png?raw=true "Downloading the web site publish profile")
	
	_Downloading the Web Site publish profile_

1. Download the publish profile file to a known location. Further in this exercise you will see how to use this file to publish a web application to a Windows Azure Web Sites from Visual Studio.

	![Saving the publish profile file](images/save-link.png?raw=true "Saving the publish profile")
	
	_Saving the publish profile file_

<a name="ApxBTask2"></a>
#### Task 2 – Configuring the Database Server ####

If your application makes use of SQL Server databases you will need to create a SQL Database server. If you want to deploy a simple application that does not use SQL Server you might skip this task.

1. You will need a SQL Database server for storing the application database. You can view the SQL Database servers from your subscription in the Windows Azure Management portal at **Sql Databases** | **Servers** | **Server's Dashboard**. If you do not have a server created, you can create one using the **Add** button on the command bar. Take note of the **server name and URL, administrator login name and password**, as you will use them in the next tasks. Do not create the database yet, as it will be created in a later stage.

	![SQL Database Server Dashboard](images/sql-database-server-dashboard.png?raw=true "SQL Database Server Dashboard")

	_SQL Database Server Dashboard_

1. In the next task you will test the database connection from Visual Studio, for that reason you need to include your local IP address in the server's list of **Allowed IP Addresses**. To do that, click **Configure**, select the IP address from **Current Client IP Address** and paste it on the **Start IP Address** and **End IP Address** text boxes and click the ![add-client-ip-address-ok-button](images/add-client-ip-address-ok-button.png?raw=true) button.

	![Adding Client IP Address](images/add-client-ip-address.png?raw=true)

	_Adding Client IP Address_

1. Once the **Client IP Address** is added to the allowed IP addresses list, click on **Save** to confirm the changes.

	![Confirm Changes](images/add-client-ip-address-confirm.png?raw=true)

	_Confirm Changes_

<a name="ApxBTask3"></a>
#### Task 3 – Publishing an ASP.NET MVC 4 Application using Web Deploy ####

1. Go back to the ASP.NET MVC 4 solution. In the **Solution Explorer**,  right-click the web site project and select **Publish**.

	![Publishing the Application](images/publishing-the-application.png?raw=true "Publishing the Application")

	_Publishing the web site_

1. Import the publish profile you saved in the first task.

	![Importing the publish profile](images/importing-the-publish-profile.png?raw=true "Importing the publish profile")

	_Importing publish profile_

1. Click **Validate Connection**. Once Validation is complete click **Next**.

	> **Note:** Validation is complete once you see a green checkmark appear next to the Validate Connection button.

	![Validating connection](images/validating-connection.png?raw=true "Validating connection")

	_Validating connection_

1. In the **Settings** page, under the **Databases** section, click the button next to your database connection's textbox (i.e. **DefaultConnection**).

	![Web deploy configuration](images/web-deploy-configuration.png?raw=true "Web deploy configuration")

	_Web deploy configuration_

1. Configure the database connection as follows:
	* In the **Server name** type your SQL Database server URL using the _tcp:_ prefix.
	* In **User name** type your server administrator login name.
	* In **Password** type your server administrator login password.
	* Type a new database name.

	![Configuring destination connection string](images/configuring-destination-connection-string.png?raw=true "Configuring destination connection string")

	_Configuring destination connection string_

1. Then click **OK**. When prompted to create the database click **Yes**.

	![Creating the database](images/creating-the-database.png?raw=true "Creating the database string")

	_Creating the database_

1. The connection string you will use to connect to SQL Database in Windows Azure is shown within Default Connection textbox. Then click **Next**.

	![Connection string pointing to SQL Database](images/sql-database-connection-string.png?raw=true "Connection string pointing to SQL Database")

	_Connection string pointing to SQL Database_

1. In the **Preview** page, click **Publish**.

	![Publishing the web application](images/publishing-the-web-application.png?raw=true "Publishing the web application")

	_Publishing the web application_

1. Once the publishing process finishes, your default browser will open the published web site.


<a name="AppendixC"></a>
## Appendix C: Using Code Snippets ##

With code snippets, you have all the code you need at your fingertips. The lab document will tell you exactly when you can use them, as shown in the following figure.

 ![Using Visual Studio code snippets to insert code into your project](./images/Using-Visual-Studio-code-snippets-to-insert-code-into-your-project.png?raw=true "Using Visual Studio code snippets to insert code into your project")
 
_Using Visual Studio code snippets to insert code into your project_

_**To add a code snippet using the keyboard (C# only)**_

1. Place the cursor where you would like to insert the code.

1. Start typing the snippet name (without spaces or hyphens).

1. Watch as IntelliSense displays matching snippets' names.

1. Select the correct snippet (or keep typing until the entire snippet's name is selected).

1. Press the Tab key twice to insert the snippet at the cursor location.

 
   ![Start typing the snippet name](./images/Start-typing-the-snippet-name.png?raw=true "Start typing the snippet name")
 
_Start typing the snippet name_

   ![Press Tab to select the highlighted snippet](./images/Press-Tab-to-select-the-highlighted-snippet.png?raw=true "Press Tab to select the highlighted snippet")
 
_Press Tab to select the highlighted snippet_

   ![Press Tab again and the snippet will expand](./images/Press-Tab-again-and-the-snippet-will-expand.png?raw=true "Press Tab again and the snippet will expand")
 
_Press Tab again and the snippet will expand_

_**To add a code snippet using the mouse (C#, Visual Basic and XML)**_
1. Right-click where you want to insert the code snippet.

1. Select **Insert Snippet** followed by **My Code Snippets**.

1. Pick the relevant snippet from the list, by clicking on it.

 
  ![Right-click where you want to insert the code snippet and select Insert Snippet](./images/Right-click-where-you-want-to-insert-the-code-snippet-and-select-Insert-Snippet.png?raw=true "Right-click where you want to insert the code snippet and select Insert Snippet")
 
_Right-click where you want to insert the code snippet and select Insert Snippet_

 ![Pick the relevant snippet from the list, by clicking on it](./images/Pick-the-relevant-snippet-from-the-list,-by-clicking-on-it.png?raw=true "Pick the relevant snippet from the list, by clicking on it")
 
_Pick the relevant snippet from the list, by clicking on it_