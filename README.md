Implement an API project built in .NET (prefer .NET Core) to manage products with the typical
CRUD methods to create, update and remove products* into a database.
Using the API, one should be able to get these resources from it:
1. Authentication: for the demo project you could hard-code the user and password into the
system, you don't have to create the access to the database (think about consuming the API by
web clients)
2. Product list: returning list of products with Id, Name, Available and Price (available for
anonymous users too)
3. Product details by id: basic information to the product Id, Name, Available, Price, Description,
DateCreated (available for anonymous users too)
4. Add product: adds new product into the system (only for authenticated users) - take care of
duplicate product names
5. Update product: updates product information (only for authenticated users)
6. Delete product: deletes product from the system (only for authenticated users)
The service must be implemented in C# and the API must follow a RESTful design/architecture
and could use JSON data exchange format.
The aim of this exercise is not just to produce working code, but also to think about potential
problems and solutions that come with the higher load and concurrency issues that could arise
when a product availability gets updated.
You are free to use whatever libraries, frameworks and middleware you like.
The project should be implemented in a public github repository, so we can review the code.
Work on separate branches for each task (1 to 6). Before submitting the code, make sure you
merged everything to master, the branch that we will review.
If you have any questions during the work on the project don't hesitate to contact me.
* Product model schema:
- Id - unique identifier
- Name
- Price
- Available (boolean)
- Description
- DateCreated
