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