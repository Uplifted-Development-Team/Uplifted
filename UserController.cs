using Microsoft.AspNetCore.Mvc;
using Uplifted.DataAccessAPI.Contracts;
using Uplifted.DataAccessAPI.Models;


namespace Uplifted.DataAccessAPI.Controllers
{
    public static class UserController
    {
        /// <summary>
        /// Service used to add user endpoints to program.
        /// </summary>
        /// <param name="app"></param>
        public static void AddUserEndpoints(this WebApplication app)
        {
            //has 500 error for some reason regarding a primary key dictionary. Endpoint still works, see this for details: https://github.com/supabase-community/supabase-csharp/issues/174
            app.MapPost("/users", async (CreateUserRequest request, Supabase.Client client) =>
            {
                var user = new User
                {
                    CreatedAt = DateTime.UtcNow,
                    UserID = request.UserID,
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    IsActive = request.IsActive,
                    DateTimeLastActive = DateTime.UtcNow
                };

                var response = await client.From<User>().Insert(user);

                var newUser = response.Models.First();
                var result = new
                {
                    UserID = newUser.UserID,
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    IsActive = newUser.IsActive,
                    DateTimeLastActive = newUser.DateTimeLastActive
                };
                return Results.Created($"/users/{newUser.UserID}", newUser);
            }).WithTags("User");

            app.MapGet("/users/{id}", async (long id, Supabase.Client client) =>
            {
                var response = await client
                .From<User>()
                .Where(n => n.Id == id)
                .Get();

                var user = response.Models.FirstOrDefault();

                if (user is null)
                {
                    return Results.NotFound();
                }

                var userResponse = new UserResponse
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                };

                return Results.Ok(userResponse);
            }).WithTags("User");

            app.MapDelete("/users/{id}", async (long id, Supabase.Client client) =>
            {
                await client
                .From<User>()
                .Where(n => n.Id == id)
                .Delete();
            }).WithTags("User");

            app.MapPatch("/users/update/{id}", async (long id, CreateUserRequest request, Supabase.Client client) =>
            {
                //if user exists
                //check each attribute of the incoming request. If it is not the default/existing value, update it

                var get = await client
                .From<User>()
                .Where(n => n.Id == id)
                .Get();

                var user = get.Models.FirstOrDefault();

                if (user is null)
                {
                    return Results.NotFound();
                }

                user.UserID = request.UserID;
                user.UserName = request.UserName;
                user.IsActive = request.IsActive;

                // Conditionally updated (nullable fields)
                if (request.Email is not null) user.Email = request.Email;
                if (request.Password is not null) user.Password = request.Password;
                if (request.FirstName is not null) user.FirstName = request.FirstName;
                if (request.LastName is not null) user.LastName = request.LastName;


                await client.From<User>().Update(user);

                var response = new UserResponse
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Email = user.Email,
                    // Consider omitting Password from responses
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                };

                return Results.Ok(response);
            }).WithTags("User");
        }
    }
}
