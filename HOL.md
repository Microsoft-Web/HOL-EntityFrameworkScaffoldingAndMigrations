<a name="HOLTop" />
# ASP.NET MVC 4 Entity Framework Scaffolding and Migrations #

---

<a name="Overview" />
## Overview ##

If you are familiar with MVC4 controller methods, or have completed the "Helpers, Forms and Validation" Hands-On lab, you should be aware that many of the logic to create, update, list and remove any data entity it is repeated among the application. Not to mention that, if your model has several classes to manipulate, you will be likely to spend a considerable time writing the POST and GET action methods for each entity operation, as well as each of the views.

In this lab you will learn how to use the ASP.NET MVC 4 scaffolding to automatically generate the baseline of your application's CRUD (Create, Read, Update and Delete). Starting from a simple model class, and, without writing a single line of code, you will create a controller that will contain all the CRUD operations, as well as the all the necessary views. After building and running the simple solution, you will have the application database generated, together with the MVC logic and views for data manipulation.

In addition, you will learn how easy it is to use Entity Framework Migrations to perform model updates throughout your entire application. Entity Framework Migrations will let you modify your database after the model has changed with simple steps. With all these in mind, you will be able to build and maintain web applications more efficiently, taking advantage of the latest features of MVC4.

<a name="Objectives" />
### Objectives ###

In this Hands-On Lab, you will learn how to:

- Use ASP.NET scaffolding for CRUD operations in controllers.
- Change the database model using Entity Framework Migrations.

<a name="SystemRequirements" />
### System Requirements ###

You must have the following items to complete this lab:

- Visual Studio 11 Express Beta for Web


<a name="Setup" />
### Setup ###

<a name="InstallingCodeSnippets" />
#### Installing Code Snippets####
For convenience, much of the code you will be managing along this lab is available as Visual Studio code snippets. To install the code snippets run the **.\Source\Assets\CodeSnippets.vsi** file.

<a name="InstallingWebPI" />
####Installing Web Platform Installer####
This section assumes that you don't have some or all the system requirements installed. In case you do, you can simply skip this section.

Microsoft Web Platform Installer (WebPI) is a tool that manages the installation of the prerequisites for this Lab.

> **Note:** As well as the Microsoft Web Platform, WebPI can also install many of the open source applications that are available like Umbraco, Kentico, DotNetNuke and many more.  These are very useful for providing a foundation from which to customize an application to your requirements, dramatically cutting down your development time.

Please follow these steps to downloads and install Microsoft Visual Studio 11 Express Beta for Web:

1. Install **Visual Studio 11 Express Beta for Web**. To do this, Navigate to [http://www.microsoft.com/web/gallery/install.aspx?appid=VWD11_BETA&prerelease=true](http://www.microsoft.com/web/gallery/install.aspx?appid=VWD11_BETA&prerelease=true) using a web browser. 

	![Web Platform Installer 4.0 window](./images/Microsoft-Web-Platform-Installer-4.png?raw=true "Web Platform Installer 4.0 download")

	_Web Platform Installer 4.0 download_

1. The Web Platform Installer launches and shows Visual Studio 11 Express Beta for Web Installation. Click on **Install**.

 	![Visual Studio 11 Express Beta for Web Installer window](./images/Microsoft-VS-11-Install.png?raw=true "Visual Studio 11 Express Beta for Web Installer window")
 
	_Visual Studio 11 Express Beta for Web Installer window_

1. The **Web Platform Installer** displays the list of software to be installed. Accept by clicking **I Accept**.

 	![Web Platform Installer window](./images/Microsoft-Web-Platform-Installer-Prerequisites.png?raw=true "Web Platform Installer window")
 
	_Web Platform Installer window_

1. The appropriate components will be downloaded and installed.

 	![Web Platform Installation - Download progress](./images/Web-Platform-Installation-Download-progress.png?raw=true "Web Platform Installation - Download progress")
 
	_Web Platform Installation - Download progress_

1. The **Web Platform Installer** will resume downloading and installing the products. When this process is finished, the Installer will show the list of all the software installed. Click **Finish**.

 	![Web Platform Installer](./images/Web-Platform-Installer.png?raw=true "Web Platform Installer")
 
	_Web Platform Installer_

1. Finally the Web Platform Installer shows the installed products. Click **Finish** to finish the setup process.

---

<a name="Exercises" />
## Exercises ##
The following exercises make up this Hands-On Lab:

1. [Using MVC 4 Scaffolding with Entity Framework Migrations](#Exercise1)


Estimated time to complete this lab: **30 minutes**

<a name="Exercise1" />
### Exercise 1: Using MVC 4 Scaffolding with Entity Framework Migrations###

ASP.NET MVC scaffolding provides a quick way to generate the CRUD operations in a standardized way, creating the necessary logic that lets your application interact with the database layer.

In this exercise, you will learn how to use MVC 4 scaffolding with code first to create the CRUD methods. 
Then, you will learn how to update your model applying the changes in the database by using Entity Framework Migrations.

<a name="Ex1Task1" />
####Task 1- Creating a new MVC 4 project using Scaffolding####

1. Start Microsoft Visual Studio 11 from **Start** | **All Programs** | **Microsoft Visual Studio 11 Express** | **Visual Studio 11 Express Beta for Web**.

1. Select **File | New Project**. In the New Project dialog, under the **Visual C# | Web** section, select the **ASP.NET MVC4** project. Name it **MVC4andEFMigrations** and click **OK**.

 	![New ASP.NET MVC 4 Project Dialog Box](./images/add-new-mvc-project.png?raw=true "New ASP.NET MVC 4 Project Dialog Box")
 
	_New ASP.NET MVC 4 Project Dialog Box_

1. In the **New ASP.NET MVC 4 Project** dialog box select the **Internet Application** template, and make sure that **Razor** is the selected **View engine**. Click **OK** to create the new project.

	 ![New ASP.NET MVC 4 Internet Application](./images/add-new-mvc-project-internet-app.png?raw=true "New ASP.NET MVC 4 Internet Application")
 
	_New ASP.NET MVC 4 Internet Application_

1. In the Package Manager Console, write the following command to update Entity Framework to its latest version: 

	<!--mark:1-->
	````PMConsole
	Update-Package EntityFramework
	````
	
	![Updating Entity Framework](images/pmc-updating-EF.png?raw=true "Updating Entity Framework")

	_Updating Entity Framework_

1. In the Solution Explorer, right-click **Models** and select **Add | Class** to create a simple class person (POCO). Name it _Person_ and click **OK**.

1. Open the Person class and insert the following three attributes.

	(Code Snippet - _ASP.NET MVC4 and Entity Framework Migrations - Ex01 Class Person_)
	
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

1. Click **Debug | Build** to save the changes and build the project.

	![Building the application](images/visual-studio-build-application.png?raw=true "Building the application")

	_Building the Application_

1. In the Solution Explorer, right-click the controllers folder and select **Add | Controller**. 

1. Name the controller _PersonController_ and complete the **Scaffolding options** with the following values.	
	- In the **Template** drop-down list, select the **Controller with read/write actions and views, using Entity Framework** option.
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
	
>**Note:** Before running the application, open global.asax and fix the database connection string (This issue is part of the MVC4 Beta Release Notes).
>
> 1. Open **global.asax.cs** and add another slash (**\\**) to the connection string Data source:
>
> <!-- mark:2 -->
> ````C#
> Database.DefaultConnectionFactory = 
>new SqlConnectionFactory("Data Source=(localdb)\\v11.0; Integrated Security=True;
>MultipleActiveResultSets=True");
>````

 
>
>**Note:** If you have the **SQLEXPRESS** service running, open **Web.config** and make sure you have the following connection string in the EntityFramework section at the end of the file.
>
><!-- mark:3 -->
>````XML
> <entityFramework>
>  ...
><parameter value="Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True" />
>..
></entityFramework>
>````


1. Press **F5** to run the application.

1. In the browser, add **/Person** to the URL to open the Person page. 

	![Application first run](images/application-first-run.png?raw=true "Application first run")

	_Application: first run_

	
1. You will now explore the Person pages and test the CRUD operations.

	1. Click **Create New** to add a new person. Enter a first name and a last name and click **Create**.

		![Adding a new person](images/adding-a-new-person.png?raw=true "Adding a new person")

		_Adding a new person_

	1. Click **Details** to open the person's details. Then, click **Back to List**.

		![Person's details](images/person-details.png?raw=true "Person's details")

		_Person's details_

	1. In the person's list, you can delete, edit or add items.

		![person list](images/person-list.png?raw=true "person list")

		_Person list_

	
1. Close the browser and return to Visual Studio.
Notice that you have created the whole CRUD for the person entity throughout your application- from the model to the views - without having to write a single line of code!.

<a name="Ex1Task3" />
####Task 3- Updating the database using Entity Framework Migrations#

In this task you will update the database using Entity Framework Migrations. You will discover how easy it is to change the model and reflect the changes in your databases by using the Entity Framework Migrations feature.

1. In the Package Manager Console, enter the following command:
	
	<!-- mark:1 -->
	````PMC
	Enable-Migrations
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

1. Select **Debug | Build** on the menu to build the application.

	![Building the application](images/visual-studio-build-application.png?raw=true "Building the application")

	_Building the application_

1. In the Package Manager Console, enter the following command:

	<!-- mark:1 -->
	````PMC
	Add-Migration AddMiddleName
	````
	
	This command will look for changes in the data objects, and then, it will add the necessary commands to modify the database accordingly.
	
	![Adding a middle name](images/PMC-adding-middle-name.png?raw=true "Adding a middle name")

	_Adding a middle name_


1. (Optional) You can execute the following command to generate a SQL script with the differential update. This will let you update the database manually (In this case it's not necessary), or apply the changes in other databases:
	
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

---

<a name="Summary" />
## Summary ##

In this Hands-On lab, you have learned simple steps to create CRUD operations with MVC 4 Scaffolding using any model class. Then, you have learned how to perform an end to end update in your application -from the database to the views- by using Entity Framework Migrations.
