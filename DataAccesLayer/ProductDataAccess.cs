public interface ProductDataAccess {


    public Product GetProduct(int id);
    public List<Product> GetProducts();
    public int CreateProduct(Product product);


}
