using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 4!");
app.MapPost("/user", () => new {name ="Thiago Leandro", age = 28 });
app.MapGet("/AddHeader", (HttpResponse response) => {
     response.Headers.Add ("Teste", "Thiago Leandro");
     return new {Name = "Thiago Leandro", Age = 28};
     });

app.MapPost("/saveproduct", (Product product) => {
    return product.Code + " - " + product.Name;
});

//api.app.com/users?datastart={date}&dataend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

//api.app.com/user/{code}
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();

public class Product {
    public int Code { get; set; }
    public String Name { get; set; }

}