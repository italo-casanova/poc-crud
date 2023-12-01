public class ProductServiceImp : ProductService {

    private readonly ProductDataAccess dataAccess;


    public List<Product> GetProducts() {
        return dataAccess.GetProducts();
    }

    public Product GetProductById(int id) {
        Product product = dataAccess.GetProductById(id);
        if (product == null)
            return new Product();
        return product;
    }

    public int AddProduct(Product product) {
        return dataAccess.CreateProduct(product);
    }

    public int UpdateProduct(Product product, int id) {
        if (dataAccess.GetProductById(id) == null)
            return -1;
        return dataAccess.UpdateProduct(product, id);
    }

    public int DeleteProduct(int id) {
        if (dataAccess.GetProductById(id) == null)
            return -1;
        return dataAccess.DeleteProduct(id);
    }

}
