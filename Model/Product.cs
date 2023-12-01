using System.ComponentModel.DataAnnotations;

public class Product {

    public int productId { get; set; }
    public string productCode { get; set; }
    public string productCategory { get; set; }
    public decimal productPrice { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
    public string? productName { get; set; }

}
