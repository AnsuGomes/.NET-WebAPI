using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//https://localhost:1996/getproduct?datestart=x5&dateend=y9
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

//https://localhost:1996/getproduct/17
app.MapGet("/getproduct/{code}", ([FromRoute]string code) => {
    return code;
});

app.Run();


