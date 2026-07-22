using Microsoft.AspNetCore.Http.HttpResults;

namespace Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            List<Product> products = new()
            {
                new() {id = 1, name= "tv"},
                new() {id = 2, name = "Phone"}
            };

            app.MapGet("/products", async (HttpContext context) =>
            {
                string result = string.Join("\n", products.Select(s => s.ToString()));

                return context.Response.WriteAsync(result);
            });

            app.MapPost("/products", async (HttpContext context, Product product) =>
            {
                products.Add(product);
                return context.Response.WriteAsync("Product Added Successfully");
            });



            //app.MapGet("/", async (HttpContext httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("Hello GETt");
            //});

            //app.MapPost("/", async (HttpContext httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("It is POST");
            //});

            app.Run();
        }
    }
}
