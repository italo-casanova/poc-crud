using System.ComponentModel.DataAnnotations;

public class Product {

    private int productId { get; set; }
    private string productCode { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    private string? productName { get; set; }
    private string? productDescription;
    private float productPrice { get; set; }

    public Product() {}

    public Product(int productId, string productCode, string productName, string productDescription) {
        this.productId = productId;
        this.productCode = productCode;
        this.productName = productName;
        this.productDescription = productDescription;
    }

    public Product(string name, string description, string code, float price) {
        this.productName = name;
        this.productDescription = description;
        this.productCode = code;
        this.productPrice = price;
    }

    public string getProductCode() {
        return this.productCode;
    }

    public string getProductName() {
        return this.productName;
    }

    public string getProductDescription() {
        return this.productDescription;
    }

    public void setProductCode(string code) {
        this.productCode = code;
    }

    public float getProductPrice() {
        return this.productPrice;
    }


}
