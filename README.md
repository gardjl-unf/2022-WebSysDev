1.  Unzip EVehiclesB.zip to the root of the source\repo directory in your home directory

2.  Open it with Visual Studio

If this is the first time you have installed this project follow the below:

3.  Since there is no database one has to be create

-- Open Tools => NuGetPackage Manager => Package Manager Console

4.  In the NuGet console widow issue the below two commands

Add-Migration Initial
Update-Database (ignore validation error concerning price)

5.  At this point the database has been created but there is no data

6.  Got to View => SQL Server Object Explorer

expand (localdb)MSSQLLocalDB...
expand Databases
expand EVehiclesB
expand Tables
click on dbo.Products but do not select anything
Underneath the label "SQL SERVER Object Explorer" there are three icons
Select the one to the left for new query

I have the insert statements to load the initial file in the EVehiclesB
main folder named dbo.Products.data.sql.  Open that file with notepad 
and copy the contents.  Then then paste it into the window. 
Then simply click the green error to execute.  

To see the data just right-click click on the products table and select View Data


***************** TODO *******************************

* There are admin accounts but add a module for customer accounts

* Add an email field to orders

* Add a lookup text field for email like the one for orderid

* The thank you screen has orderid, add the model selected

* Fix the logout button that she has to return to the home page

* Add a link on the product pages to pop up a display all model stats like Tesla has. Javascript

* Add images on the add screens for the products, model, paint, rims, etc.

* Fix static pages, move to views


Login:
	CAN ACCESS /Admin/MainAdmin from a logged out user
	Delete User gives error "User Not Found"
	Edit User doesn't fucking do anything
	Admin/Delete not found (should be in "Edit"?)
	Edit Product Goes to a Specific Edit Page
