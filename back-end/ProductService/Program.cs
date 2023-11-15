using Microsoft.EntityFrameworkCore;
using ProductService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ProductsContext>(options => options.UseInMemoryDatabase("Products"));

var app = builder.Build();

SeedDB(app);

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductService.Services.ProductService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();

static void SeedDB(WebApplication app)
{
    using IServiceScope scope = app.Services.CreateScope();
    using ProductsContext context = scope.ServiceProvider.GetRequiredService<ProductsContext>();
    ProductContextSeed.Seed(context);
}