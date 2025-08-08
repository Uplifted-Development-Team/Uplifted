namespace Uplifted.DataAccessAPI.Extensions
{
    public static class DependenciesConfig
    {
        /// <summary>
        /// Extension method for builder to add dependencies.
        /// </summary>
        /// <param name="builder"></param>
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            var supabaseUrl = builder.Configuration["Supabase:SUPABASE_URL"];
            var supabaseKey = builder.Configuration["Supabase:SUPABASE_KEY"];
            builder.Services.AddSupabaseService(supabaseUrl, supabaseKey);
        }
    }
}
