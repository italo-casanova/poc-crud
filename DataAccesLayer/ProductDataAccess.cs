public interface ProductDataAccess {

    public Product GetProductById(int id);
    public List<Product> GetProducts();
    public int CreateProduct(Product product);
    public int UpdateProduct(Product product, int id);
    public int DeleteProduct(int id);

}
