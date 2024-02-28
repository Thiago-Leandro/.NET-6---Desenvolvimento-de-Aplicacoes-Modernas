using Microsoft.AspNetCore.Authorization.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 4!");
app.MapPost("/user", () => new {name ="Thiago Leandro", age = 28 });
app.MapGet("/AddHeader", (HttpResponse response) => {
     response.Headers.Add ("Teste", "Thiago Leandro");
     return new {Name = "Thiago Leandro", Age = 35};
     });

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

app.Run();

public class Product {
    public int Code { get; set; }
    public String Name { get; set; }

}