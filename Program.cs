using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Insert the product.
app.MapPost("/saveproduct", (Product produtc) => {
    ProductReposiory.Add(produtc);
});

//check the product.
app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>{
    var product = ProductReposiory.GetBy(code);
    return product;
});

//Edit the product.
app.MapPut("/editproduct", (Product product) => {
    var productSaved = ProductReposiory.GetBy(product.Code);
    productSaved.Name = product.Name;
});

//Delete the product.
app.MapDelete("/deleteproduct/{code}", ([FromRoute] string code)=> {
    var productSaved = ProductReposiory.GetBy(code);
    ProductReposiory.Remove(productSaved);
});

app.Run();

public static class ProductReposiory{
    public static List<Product> Products { get; set; }

    public static void Add(Product product){
        if(Products == null)
            Products = new List<Product>();
        Products.Add(product);    
    }

    public static Product GetBy(string code){
        return Products.FirstOrDefault(p =>p.Code == code); //If not found, show default response.
    }

    public static void Remove(Product product){
        Products.Remove(product);
    }
}

public class Product {
    public string Code { get; set; }

    public string Name { get; set; }
}