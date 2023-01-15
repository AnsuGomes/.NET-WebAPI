using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/saveproduct", (Product produtc) => {
    ProductReposiory.Add(produtc);
});

app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>{
    var product = ProductReposiory.GetBy(code);
    return product;
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
}

public class Product {
    public string Code { get; set; }

    public string Name { get; set; }
}