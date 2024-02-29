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
    ProductRepository.Add(product);
});

//api.app.com/users?datastart={date}&dataend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});

app.Run();

public static class ProductRepository {
    public static List<Product> Products { get; set; }

    static ProductRepository() {
        Products = new List<Product>();
    }

    public static void Add(Product product){
        if(Products == null)
            Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code) {
        return Products.FirstOrDefault(p => p.Code == code);
    }
}

public class Product {
    public string Code { get; set; }
    public string Name { get; set; }
}
