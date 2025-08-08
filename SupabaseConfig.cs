using System.Runtime.CompilerServices;
using Supabase;
namespace Uplifted.DataAccessAPI.Extensions
{
    public static class SupabaseConfig
    {
        /// <summary>
        /// Adds Supabase client as a scoped service to dependency injection container,
        /// sets up the client with provided URL and API key, 
        /// configures auto refresh and connect real time, and inits client sync.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="url"></param>
        /// <param name="key"></param>
        public static void AddSupabaseService(this IServiceCollection services, string url, string key)
        {
            services.AddScoped<Client>(provider =>
            {
                var options = new SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true,
                };

                var supabaseClient = new Client(url, key, options);
                supabaseClient.InitializeAsync().Wait();
                return supabaseClient;
            });
        }
    }
}
