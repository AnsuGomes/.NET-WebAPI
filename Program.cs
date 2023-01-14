using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//DEVE-SE COLOCAR NO HEADERS KEY E VALUE NO POSTMAN.
app.MapGet("/getproduct", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();


