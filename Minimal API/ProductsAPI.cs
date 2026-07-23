using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Minimal_API
{
    public static class ProductsAPI
    {
        public static
            List<Product> products = new()
            {
                new() {id = 1, name= "tv"},
                new() {id = 2, name = "Phone"}
            };

        public static RouteGroupBuilder AttachAPI(this RouteGroupBuilder builder)
        {
            builder.MapGet("/", async (HttpContext context) =>
            {
                string result = string.Join("\n", products.Select(s => s.ToString()));

                return context.Response.WriteAsync(result);
            });

            builder.MapPost("/", async (HttpContext context, Product product) =>
            {
                products.Add(product);
                await context.Response.WriteAsync("Product Added Successfully");
            });


            builder.MapGet("/{id:int}", async (HttpContext context, int id) =>
            {
                Product? product = products.FirstOrDefault(s => s.id == id);

                if (product == null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invlaid Product Id");
                    return;
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(product));
            });


            builder.MapPut("/{id:int}", async (HttpContext context, int id, [FromBody] Product productFromBody) =>
            {

                Product? product = products.FirstOrDefault(s => s.id == id);

                if (product == null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invlaid Product Id");
                    return;
                }

                product.name = productFromBody.name;
                await context.Response.WriteAsync("Products Edited Successfully");
            });

            builder.MapDelete("/{id:int}", async (HttpContext context, int id) =>
            {

                Product? product = products.FirstOrDefault(s => s.id == id);

                if (product == null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invlaid Product Id");
                    return;
                }

                products.Remove(product);
                await context.Response.WriteAsync("Products Deleted Successfully");
            });

            return builder;

        }

    }
}
