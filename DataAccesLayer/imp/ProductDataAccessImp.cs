using Microsoft.Data.SqlClient;

public class ProductDataAccessImp: ProductDataAccess {
    private readonly string connectionString;

    public ProductDataAccessImp(string connectionString) => this.connectionString = connectionString;

    public Product GetProductById(int id) {
        Product p = null;
        using (var connection = new SqlConnection(connectionString)) {
            connection.Open();
            using (var command = connection.CreateCommand()) {

                command.CommandText = @"
                    SELECT name, description, code, price
                    FROM Products
                    WHERE Id = @id";

                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader()) {

                    if (reader.Read()) {
                         p = new Product (
                            reader.GetString(reader.GetOrdinal("name")),
                            reader.GetString(reader.GetOrdinal("description")),
                            reader.GetString(reader.GetOrdinal("code")),
                            reader.GetFloat(reader.GetOrdinal("price")));

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
                command.CommandText = @"
                    SELECT name, description, code, price
                    FROM product";
                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();
                    while (reader.Read())
                    {
                        var product = new Product(
                            reader.GetString(reader.GetOrdinal("name")),
                            reader.GetString(reader.GetOrdinal("description")),
                            reader.GetString(reader.GetOrdinal("code")),
                            reader.GetFloat(reader.GetOrdinal("price")));
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
                    INSERT INTO Products (name, code, description)
                    VALUES (@name, @code, @description);";

                command.Parameters.AddWithValue("@name", product.getProductName());
                command.Parameters.AddWithValue("@code", product.getProductCode());
                command.Parameters.AddWithValue("@description", product.getProductDescription());

                return (int)(decimal)command.ExecuteScalar();
            }
        }
    }

    public int UpdateProduct(Product product, int id) {
        using (var connection = new SqlConnection(connectionString)) {
            connection.Open();
            using (var command = connection.CreateCommand()) {
                command.CommandText = @"
                    UPDATE Products
                    SET name = @name, code = @code, description = @description
                    WHERE Id = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", product.getProductName());
                command.Parameters.AddWithValue("@code", product.getProductCode());
                command.Parameters.AddWithValue("@description", product.getProductDescription());

                return command.ExecuteNonQuery();
            }
        }
    }

    public int DeleteProduct(int id) {
        using (var connection = new SqlConnection(connectionString)) {
            connection.Open();
            using (var command = connection.CreateCommand()) {
                command.CommandText = @"
                    DELETE FROM Products
                    WHERE Id = @id;";
                command.Parameters.AddWithValue("@id", id);

                return command.ExecuteNonQuery();
            }
        }
    }

}
