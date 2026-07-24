using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();


            var mapGp = app.MapGroup("/products").AttachAPI();



            app.Run();
        }
    }
}
