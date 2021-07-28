# SupplierManagementNew
Projects Supplier Management Api and MVC

The project was implemented using 2 projects in the SupplierManagementNEW solution.

In the 1st project SupplierManagementAPI a Cotroller was created named Supplier to accept the
REST calls tangible 2nd project and store valuable information in the database.
The base association with the 1st project via EntityFramewotk and connectionstring in Web.config.
Finally in Web.config there are the necessary conditions for sending Email when you create
a Supplier.

In the 2nd project SupplierManagamentMVC the user interacts where he can implement C.R.U.D.
operation, there are custom validation in Create, Update. In fact, the user has a limit
in Update which fields will change when Supplier is Active or Inactive. Finally it can
select by filtering the list according to Category Supplier which Suppliers it will see.

In order for the application to run, the SupplierManagementAPI project must first be run in a browser
to change the connectionstring in Web.config to migrate and update database.
Then we open the SupplierManagementMVC where the user interacts with the application.
(The SupplierManagementAPI project tab must remain open).

Front End : JavaScript, jQuery, Bootstrap, Razor

Back End: C#, SQL, .NET MVC, Entity Framework, LINQ, Web API Client
