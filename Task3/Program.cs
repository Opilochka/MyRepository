using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Task3;Trusted_Connection=True;";
            string sqlExpression = "SELECT * FROM Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    string selectQuery = @"SELECT p.ProductName, c.CategoryName
                                    FROM Products p
                                    LEFT JOIN ProductCategory pc ON p.ProductId = pc.ProductId
                                    LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId";

                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    SqlDataReader reader_new = selectCommand.ExecuteReader();
                    while (reader_new.Read())
                    {
                        string productName = (string)reader_new["ProductName"];
                        string categoryName = reader_new["CategoryName"] == DBNull.Value ? "No category" : (string)reader_new["CategoryName"];

                        Console.WriteLine($"Product: {productName}, Category: {categoryName}");
                    }
                }
                else
                {

                    string createProductsTableQuery = @"CREATE TABLE Products (
                                                    ProductId INT PRIMARY KEY,
                                                    ProductName NVARCHAR(50)
                                                )";
                    string createCategoriesTableQuery = @"CREATE TABLE Categories (
                                                    CategoryId INT PRIMARY KEY,
                                                    CategoryName NVARCHAR(50)
                                                )";
                    string createProductCategoryTableQuery = @"CREATE TABLE ProductCategory (
                                                    ProductId INT,
                                                    CategoryId INT,
                                                    PRIMARY KEY (ProductId, CategoryId)
                                                )";

                    SqlCommand createProductsTableCommand = new SqlCommand(createProductsTableQuery, connection);
                    createProductsTableCommand.ExecuteNonQuery();

                    SqlCommand createCategoriesTableCommand = new SqlCommand(createCategoriesTableQuery, connection);
                    createCategoriesTableCommand.ExecuteNonQuery();

                    SqlCommand createProductCategoryTableCommand = new SqlCommand(createProductCategoryTableQuery, connection);
                    createProductCategoryTableCommand.ExecuteNonQuery();

                    SqlCommand insertProduct1Command = new SqlCommand("INSERT INTO Products (ProductId, ProductName) VALUES (1, 'Product1')", connection);
                    SqlCommand insertProduct2Command = new SqlCommand("INSERT INTO Products (ProductId, ProductName) VALUES (2, 'Product2')", connection);
                    SqlCommand insertProduct3Command = new SqlCommand("INSERT INTO Products (ProductId, ProductName) VALUES (3, 'Product3')", connection);
                    insertProduct1Command.ExecuteNonQuery();
                    insertProduct2Command.ExecuteNonQuery();
                    insertProduct3Command.ExecuteNonQuery();

                    SqlCommand insertCategory1Command = new SqlCommand("INSERT INTO Categories (CategoryId, CategoryName) VALUES (1, 'Category1')", connection);
                    SqlCommand insertCategory2Command = new SqlCommand("INSERT INTO Categories (CategoryId, CategoryName) VALUES (2, 'Category2')", connection);
                    insertCategory1Command.ExecuteNonQuery();
                    insertCategory2Command.ExecuteNonQuery();

                    SqlCommand insertProductCategory1Command = new SqlCommand("INSERT INTO ProductCategory (ProductId, CategoryId) VALUES (1, 1)", connection);
                    SqlCommand insertProductCategory2Command = new SqlCommand("INSERT INTO ProductCategory (ProductId, CategoryId) VALUES (2, 1)", connection);
                    insertProductCategory1Command.ExecuteNonQuery();
                    insertProductCategory2Command.ExecuteNonQuery();
                }
                    

                connection.Close();
                Console.ReadLine();
            }
        }
    }
}
