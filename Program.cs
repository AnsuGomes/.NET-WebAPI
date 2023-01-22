using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Insert the product.
app.MapPost("/products", (Product produtc) => {
    ProductReposiory.Add(produtc);
    return Results.Created("/products/" + produtc.Code, produtc.Code);
});

//check the product.
app.MapGet("/products/{code}", ([FromRoute] string code) =>{
    var product = ProductReposiory.GetBy(code);
    if(product != null)
        return Results.Ok(product);
    return Results.NotFound();
});

//Edit the product.
app.MapPut("/products", (Product product) => {
    var productSaved = ProductReposiory.GetBy(product.Code);
    productSaved.Name = product.Name;
    return Results.Ok();
});

//Delete the product.
app.MapDelete("/products/{code}", ([FromRoute] string code)=> {
    var productSaved = ProductReposiory.GetBy(code);
    ProductReposiory.Remove(productSaved);
    return Results.Ok();
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