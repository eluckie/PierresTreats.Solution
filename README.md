# Pierre's Sweet and Savory Treats

#### By E. Luckie ☀️

#### This webpage application acts as a marketing tool for a bakery owner. Users are able to view all of the currrent treats offered. They are also able to create a profile to be able to add, edit, and delete treats from the page.

## Technologies Used

* C#
* .NET 7.0
* EF Core 7.0
* Identity
* MySQL Workbench
* HTML
* Markdown
* Git

## Description
_{This is a detailed description of your application. Give as much detail as needed to explain what the application does as well as any other information you want users or other developers to have.}_

### Paths

**/** Home page welcoming user to {Dr. Sillystringz's}. Contains an overview list of current {engineers} & current {machines}. Also has links to manage or add {engineers}, and manage or add {machines}

**/{Engineers}** {Engineers} main page showing full list of current {engineers} and their pronouns

**/{Machines}** {Machines} main page showing full list of current {machines} and their respective {engineers}

**/{{Engineers} or {Machines}}/Create** A form to add a new machine or engineer (depending on which link was clicked)

**/{Engineers}/Details/{id}** A page that displays the selected engineer's name, pronouns, hire date, and any current machine ceritifications. Includes links to add a new machine to this engineer, edit this engineer, delete this engineer, return back to the full list of {engineers}, see the full list of {machines}, or return to the home page. Also includes a clickable button to un-certify engineer from any specific machine

**/{{Engineers} or {Machines}}/Edit/{id}** A form to edit the current machine or engineer (depending on which link was clicked). Both forms include links that say _NVM NVM NVM_ and take the user back to the selected detail pages, and links to instead manage the {machines} or {engineers}, or go back to the main page

**/{{Engineers} or {Machines}}/Delete/{id}** A page confirming you'd like to delete the selected engineer or machine. Clicking the button officially deletes them, and re-routes the user back to the respective main pages displaying the full list of {engineers} or {machines}. If user clicks the _NVM NVM NVM_ link instead of the button, the selected machine or engineer is not deleted, and the user is re-routed back to the selected's details page

**/{Machines}/Details/{id}** A page that displays the selected machine's name, description, install date, and any technicians certified for that machine. From there, the user is also able to choose to edit or delete the selected machine, as well as add some new {engineers} to be certified

**/{Machines}/AddEngineer/{id}** A page that displays the selected machine's name and a drop down list of current {engineers}. The user is able to select one engineer from the list at a time to _Make it official_ which will certify the selected engineer and re-route to the selected machine's details page, showing the updated list of certified {engineers}

**/{Engineers}/AddRepairs/{id}** A page that displays the selected engineer's name and a form to select checkboxes of the current {machines}. The user is able to select multiple {machines} from the list and click _Let's gooooo_ which will certify the selected engineer and re-route to their details page, showing the updated list of certifications


## Setup/Installation Requirements

1. Clone this repository
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called _**Treats**_.
3. In the command line, run the command ``dotnet restore`` to restore the necessary packages for the application to run
4. Within the production level of this directory, called _**Treats**_, create a new file called **appsettings.json**
5. Input the following code into your _**appsettings.json**_ file

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```

* Replace _[ YOUR-DB-NAME ]_ with the name you would like for the database that you will be utilizing via MySQL Workbench
* Replace _[ YOUR-USER-HERE ]_ with your username for MySQL Workbench
* Replace _[ YOUR-PASSWORD-HERE ]_ with your password for MySQL Workbench
* Make sure you save the changes you've made to the file
* If you are planning on pushing your work back to GitHub to a new repository, _make sure to commit your .gitignore file first so that your sensitive information is kept private_

### Viewing the Active Project
6. In your computer's terminal, navigate to the production level of this directory called _**Treats**_
7. In the command line, run the command ``dotnet ef database update``
* This will create a new database for the project in MySQL Workbench named as you specified in the _appsettings.json_ file.
* You may choose to verify that the new database and related tables were created accurated in MySQL Workbench by clicking the small refresh button in the top right corner of the _Schemas_ tab. Your new database name should appear on the list and you should be able to click on it to view/alter the relevant tables
8. In the command line, run the command ``dotnet watch run`` to compile and execute the webpage in Development mode
* Optionally, you can run the command ``dotnet build`` to compile the program without running it


## Known Bugs

* _Any known issues_
* _should go here_

## Stretch Plans

* Have separate roles for admins & logged-in users. Only admins should be able to CUD
* Add an order form that only logged-in users can access. Logged-in users should be able to CRUD their own orders

## License

MIT License

Copyright (c) 2023 Luckie