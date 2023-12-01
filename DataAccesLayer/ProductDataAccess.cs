using Dapper;
using Microsoft.Data.SqlClient;

public class ProductDataAccess {
    private readonly string connectionString;

    public ProductDataAccess(string connectionString) {
        this.connectionString = connectionString;
    }

    public Product GetProduct(int id) {
        Product p = null;
        using (var connection = new SqlConnection(connectionString)) {
            connection.Open();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM Products WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                         p = new Product {
                            productId = reader.GetInt32(reader.GetOrdinal("Id")),
                            productName = reader.GetString(reader.GetOrdinal("Name")),
                            productPrice = reader.GetDecimal(reader.GetOrdinal("Price"))
                        };

                    }
                    return p;
                }
            }
        }
    }
    public List<Product> GetProducts() {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Products";
                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            productId = reader.GetInt32(reader.GetOrdinal("Id")),
                            productName = reader.GetString(reader.GetOrdinal("Name")),
                            productPrice = reader.GetDecimal(reader.GetOrdinal("Price"))
                        };
                        products.Add(product);
                    }
                    return products;
                }
            }
        }
    }

    public int CreateProduct(Product product) {
        using (var connection = new SqlConnection(connectionString)) {
            connection.Open();
            using (var command = connection.CreateCommand()) {
                command.CommandText = @"
                    INSERT INTO Products (name, price, code, category)
                    VALUES (@name, @price, @code);";
                command.Parameters.AddWithValue("@name", product.productName);
                command.Parameters.AddWithValue("@price", product.productPrice);
                command.Parameters.AddWithValue("@code", product.productCode);
                command.Parameters.AddWithValue("@category", product.productCategory);
                return (int)(decimal)command.ExecuteScalar();
            }
        }
    }


}
