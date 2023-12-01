using Microsoft.AspNetCore.Mvc;

public class ProductController {

    private ProductService service;

    [HttpGet]
    public List<Product> GetProducts() {
        return service.GetProducts();
    }

    [HttpGet("{id}")]
    public Product GetProduct(int id) {
        return service.GetProductById(id);
    }

    [HttpPost]
    public void AddProduct([FromBody] Product product) {
        service.AddProduct(product);
    }

    [HttpPut("{id}")]
    public void UpdateProduct([FromBody] Product product, int id) {
        service.UpdateProduct(product, id);
    }

    [HttpDelete("{id}")]
    public void DeleteProduct(int id) {
        service.DeleteProduct(id);
    }

}
