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
Joe 11/14 - When she logs in she calls the logout method first.  When I changed
Logout it broke login.  To get around that I created a seperate method Logout2 
and changed most of the blue buttons to point to that.  May have missed a couple,   


* Add a link on the product pages to pop up a display all model stats like Tesla has. Javascript

* Add images on the add screens for the products, model, paint, rims, etc.

* Fix static pages, move to views

* Change page structure to Controller/Action where possible to undo the Index#.cshtml pages.


Login:
	CAN ACCESS /Admin/MainAdmin from a logged out user
	Delete User gives error "User Not Found" (Should be fixed Joe 11/14)
	Edit User doesn't fucking do anything (Should be fixed Joe 11/14)
	Admin/Delete not found (should be in "Edit"?) (Should be fixed Joe 11/14)
	Edit Product Goes to a Specific Edit Page (Should be fixed Joe 11/14)

11/14 Joe - Error if you create more than one admin users with the same email

11/14 Joe
Adding E-Mail

Did a find througout the entire project searching on Country (a field in orders)
Found in numerous places and added Email where appropriate
Tried migration and update but did not get the column in the database
Google doc said to delete the database 
(which I did - stupid method but worked had to close first Visual Studio then reopen)
Then did Add-Migration Initial and Update-Database
Then re-added the data

At that point there was no Admin User.  
  - Just went back to an old solution and created one
  - Below is the create statement for it in users and created admin@evhicles.com password Temp01# 
  
  INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], 
  [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
  [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], 
  [AccessFailedCount]) VALUES (N'f70230f5-aae7-4357-96b3-08dac66fa512', N'admin', N'ADMIN', 
  N'admin@evehicles.com', N'ADMIN@EVEHICLES.COM', 0, 
  N'AQAAAAEAACcQAAAAELmEcW2NLu61UhgG/X6uZQcThxGmkN0ySoVt3+O/rkizpw6UGJrknH6/UeOrcxpyKw==', 
  N'JP7FUQ5ZKICTBGHF5GHZW5TGXO2GY7AO', N'f6d3c77a-cbda-4518-b64c-22e30b62a428', 
  NULL, 0, 0, NULL, 1, 0);

This can just be addded with the SQL scripts and loaded with the initial SQL.  
Deleted the one in the database and then ran the above and it loaded it

Then went into View\Order\List and List2 and changed name to email.

Note(List and List2 are not displaying correctly)

  









Controller and Methods

Product Controller

  -  IndexModelStart - Used to return home when syntax for returning Model is unknown
       Returns View Products/Index with "Model 3 Plaid" chosen (Home page)

  -  IndexModel(string Model) - Displays main page with model selected.
       Returns View Product/Index displaying home page with model chosen

  -  PurchaseModel(string Model) - View PurchaseModel
       Returns View Product/PurchaseModel displaying Car Picture, Info and a button to Purchase

  -  AddVehicleItem(string category, int page = 1) -  Shows next item in vehicle to add
       Return View Product/AddVehicleItem showing a list of Item to add to the Cart (Model, then Paint, then Interior, etc.

  -  List(string category, int page = 1)  //Her method for merchandise
       Return View Product/List showing a list of Merchandise that can be ordered

Order Controller

  -  List 
       Returns View Order/List displaying orders not shipped with button to ship, called in Admin Menu

  -  List2(string OrderIdString = "") 
       Returns View Ordwes/List2 displaying orders by orderID, called in Admin Menu

  -  List4(string OrderIdString = "", string OrderEmailString = "") 
       Return View Orders/List4 with button to mark shipped

  -  MarkShipped(int orderID) Method to mark shipped an orderId 
       Returns View Order/List 

  -  Checkout() Saves cart at checkout 
       Returns View Order/Completed

  -  CheckoutCar() Same as above but was used for cars.  
       Returns View Order/completedCar

  -  Completed() - Finds last Customer OrderId - View thanks showing OrderID
       Return View Order/CompletedCar which shows OrderId and thanks for purchase

  -  CompletedCar - Same as above but for Car
       Return View Order/CompletedCar which shows OrderId and thanks for Car purchase


Cart 

 -  Index(string returnUrl) returns new CartIndexViewModel Cart = cart
      Return Cart/View which displays cart with buttons to clear, continue shopping, or checkout

 -  Index2(string returnUrl) returns new CartIndexViewModel Cart = cart
      Return View Cart/Index2 which displays cart with buttons to clear or checkout

 -  DeleteAllCart() - Deletes all iems in cart 
      Return View Product/IndexModelStart which displays home page

 -  AddToCartItems(int productId, string returnUrl) - Add merchandise 
      Return View Cart/Index which displays cart with buttons to clear, continue shopping, or checkout

 -  AddToCartVehicleItem(int productId, string returnUrl) - Add Car items 
      Return View Cart/Index2 which displays cart with buttons to clear or checkout

 -  RemoveFromCart(int productId, string returnUrl) - Removes item from cart
      Returns View Cart/Index which displays cart with buttons to clear, continue shopping, or checkou

Admin

 -  Index()
      Return View Admin/Index which displays a list of products

 -  Index2() (POSSIBLE DUPLICATE OF ABOVE)
      Return View Admin/Index2 which displays a list of products
      
 -  Index3() 
      Return View Admin/Index3 which displays a list of products with an Admin/Edit button

 -  Index4()
      Returns View Admin/Index4 which displays products with a delete button to delete products

 -  Edit(int productId) - Has [HttpPost] method to save product change from form
      Return View Admin/Idex3 which shows a product info form with an edit button.

 -  AddProduct() - Adds a product to the product table
      Return View Admin/AddProduct which has a form for new product info and a save button

 -  Delete(int productId) - [HttpPost] Sets product availability to false
      Return View Admin/Index

 -  MainAdmin()
      Return View Admin/MainAdmin showing admin functions to select.

Admin Controller (Many methods.  The only one added is below)

 -  Logout2() - Logs out user
      Return View Product/IndexModel with Model set to "Model 3 Plaid"
 