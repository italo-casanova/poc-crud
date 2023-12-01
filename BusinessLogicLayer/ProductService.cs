public interface ProductService {

    public List<Product> GetProducts();
    public Product GetProductById(int id);
    public int AddProduct(Product product);
    public int UpdateProduct(Product product, int id);
    public int DeleteProduct(int id);

}
