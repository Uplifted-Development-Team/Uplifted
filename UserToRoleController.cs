using Microsoft.AspNetCore.Mvc;
using Uplifted.DataAccessAPI.Contracts;
using Uplifted.DataAccessAPI.Models;


namespace Uplifted.DataAccessAPI.Controllers
{
    public static class UserToRoleController
    {
        public static void AddUserToRoleEndpoints(this WebApplication app)
        {
            app.MapPost("/user-to-role", async (CreateUserToRoleRequest request, Supabase.Client client) =>
            {
                var mapping = new UserToRole
                {
                    UserID = request.UserID,
                    RoleID = request.RoleID
                };

                var response = await client.From<UserToRole>().Insert(mapping);
                var newMapping = response.Models.First();

                var result = new UserToRoleResponse
                {
                    UserID = newMapping.UserID,
                    RoleID = newMapping.RoleID
                };

                return Results.Created($"/user-to-role/{newMapping.UserID}-{newMapping.RoleID}", result);
            }).WithTags("User to Role");

            app.MapGet("/user-to-role/{userId}", async (long userId, Supabase.Client client) =>
            {
                var response = await client
                    .From<UserToRole>()
                    .Where(x => x.UserID == userId)
                    .Get();

                var mapping = response.Models.FirstOrDefault();

                if (mapping is null)
                {
                    return Results.NotFound();
                }

                var result = new UserToRoleResponse
                {
                    UserID = mapping.UserID,
                    RoleID = mapping.RoleID
                };

                return Results.Ok(result);
            }).WithTags("User to Role");

            app.MapDelete("/user-to-role/{userId}", async (long userId, Supabase.Client client) =>
            {
                await client
                    .From<UserToRole>()
                    .Where(x => x.UserID == userId)
                    .Delete();

                return Results.NoContent();
            }).WithTags("User to Role");

            app.MapPatch("/user-to-role/update/{userId}", async (long userId, CreateUserToRoleRequest request, Supabase.Client client) =>
            {
                var response = await client
                    .From<UserToRole>()
                    .Where(x => x.UserID == userId)
                    .Get();

                var mapping = response.Models.FirstOrDefault();

                if (mapping is null)
                {
                    return Results.NotFound();
                }

                // Update only if values are different
                if (request.UserID != default && request.UserID != mapping.UserID)
                    mapping.UserID = request.UserID;

                if (request.RoleID != default && request.RoleID != mapping.RoleID)
                    mapping.RoleID = request.RoleID;

                await client.From<UserToRole>().Update(mapping);

                var result = new UserToRoleResponse
                {
                    UserID = mapping.UserID,
                    RoleID = mapping.RoleID
                };

                return Results.Ok(result);
            }).WithTags("User to Role");
        }
    }
}
