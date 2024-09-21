using ImportBackend.Services.ImportOrders;
using ImportBackend.Services.ProductCategories;
using ImportBackend.Services.Products;
using ImportBackend.Services.Providers;
using ImportBackend.Services.Users;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<IProductService, ProductService>();
    builder.Services.AddSingleton<IUserService, UserService>();
    builder.Services.AddSingleton<IProductCategoryService, ProductCategoryService>();
    builder.Services.AddSingleton<IImportOrderService, ImportOrderService>();
    builder.Services.AddSingleton<IProviderService, ProviderService>();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
