1. **Clone the repository**
   ```bash
   git clone https://github.com/Sanjoy23/Ost_Assignment_4.git
   cd Ost_Assignment_4
2. Set up the database
  * Open Script folder in Visual Studio or SQL Server Management Studio (SSMS)
  * Execute the scripts to create the Products table and sp_FindProductById and sp_InsertProduct stored procedure
3. Configure the database connection
  * In appsettings.json, update the DefaultConnection string to match your local SQL Server setup.
  * "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;"
      }

