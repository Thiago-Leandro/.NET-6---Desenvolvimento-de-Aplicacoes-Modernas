using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration["Database:SqlServer"]));

var app = builder.Build();
var configuration = app.Configuration;
ProductRepository.Init(configuration);


app.MapPost("/products", (ProductRequest productRequest, ApplicationDbContext context) =>
{
    var category = context.Categories.Where(c.Id == productRequest.CategoryId).First();
    var product = new Product
    {
        Code = productRequest.Code,
        Name = productRequest.Name,
        Description = productRequest.Description,
        category = category
    };
    if (productRequest.Tags != null)
    {
        productRequest.Tags = new List<Tag>();
        foreach (var item in productRequest.Tags)
        {
            product.Tags.Add(new Tag { name = item });
        }
    }
    context.products.Add(product);
    context.SaveChanges();
    return Results.Created($"/products/{product.Code}", product.Code);
});

app.MapGet("/products/{code}", ([FromRoute] int Id, ApplicationDbContext) =>
{
    var product = ApplicationDbContext.Products
    .Include(product => product.Category)
    .Include(product => product.Tags)
    .Where(product => product.Id == id).First;
    if (product != null)
        return Results.NotFound();
});

app.MapPut("/products/{id}", ([FromRoute] int Id, ProductRequest productRequest, ApplicationDbContext context) =>
{
    var product = context.Products
      .Include(product => product.Category)
      .Include(product => product.Tags)
      .Where(product => product.Id == id).First;
    var category = context.Categories.Where(c.Id == productRequest.CategoryId).First();

    product.Code = productRequest.Code;
    product.Name = productRequest.Name;
    product.Description = productRequest.Description;
    product.Category = category;
    product.Tags = new List<Tag>();
    if (productRequest.Tags != null)
    {
        product.Tags = new List<Tag>();
        foreach (var item in productRequest.Tags)
        {
            product.Tags.Add(new Tag { name = item });
        }
    }

    context.SaveChanges();
    return Results.Ok();
});

app.MapDelete("/products/{Id}", ([FromRoute] int Id, ApplicationDbContext context) => {
    var product = context.Products.Where(p => p.Id == id).First;
    context.Products.Remove(product);
    ProductRepository.Remove(productSaved);
    return Results.Ok();
});

app.MapGet("/configuration/database", (IConfiguration configuration) =>
    return Results.Ok($"{configuration["Database:Connection"]}/{configuration["Database:Port"]}");
});

app.Run();