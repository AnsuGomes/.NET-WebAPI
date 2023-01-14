var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! 2");

app.MapGet("/user", () => new {name = "Ansu", Age=26});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Ansu");
    return new {Name= "Ansu", Age = 26};
});

//PARAMETRO PELO BODY - INICIO
app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

app.Run();

public class Product
{
    public string Code {get; set;}

    public string Name {get; set;}
}

//PARAMETRO PELO BODY - FIM