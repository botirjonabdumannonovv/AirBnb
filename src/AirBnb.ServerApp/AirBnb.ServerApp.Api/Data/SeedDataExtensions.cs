using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var locationsDbContext = serviceProvider.GetRequiredService<LocationsDbContext>();

        if (!await locationsDbContext.Locations.AnyAsync())
            await locationsDbContext.SeedLocationsAsync();
        
        if (!await locationsDbContext.LocationCategories.AnyAsync())
            await locationsDbContext.SeedLocationCategoryAsync();
    }

    private static async ValueTask SeedLocationsAsync(this LocationsDbContext locationsDbContext)
    {
        var images = new List<string>
        {
            "https://a0.muscache.com/im/pictures/miso/Hosting-852899544635683289/original/c627f47e-8ca9-4471-90d4-1fd987dd2362.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/d31ff0cf-e8b4-4f03-8ca4-3d91d93263bb.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/177ed8a7-557b-480f-8319-4f8330e2c692.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-696847375839509250/original/9686a3bd-dfff-4ae6-bb51-514154308bdb.png?im_w=720",
            "https://a0.muscache.com/im/pictures/d879c12a-9259-4080-847e-faeecfe176d9.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/a3e07d96-169a-41a4-81e1-e02109a28bfe.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-873059475609190432/original/6830ab30-8549-45aa-ad9f-b9428469f2a0.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-853189955208971108/original/aab48bd2-edb0-4ffd-87a3-f5cc7d7c3be2.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/1b6f3c4c-a25d-4ad5-bbf4-5042b48a2bc6.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-569509737393877126/original/82a09673-c8c7-4a5b-b7a2-0c3f53f6f1fa.jpeg?im_w=720"
        };
        var random = new Random();
        
        foreach (var image in images)
        {
            await locationsDbContext.Locations.AddAsync(new Location
            {
                ImageUrl = image,
                Name = "Tashkent, Uzbekistan",
                BuiltYear = random.Next(2000, 2023),
                PricePerNight = random.Next(300, 5000)
            });

            await locationsDbContext.SaveChangesAsync();
        }
    }

    private static async ValueTask SeedLocationCategoryAsync(this LocationsDbContext locationsDbContext)
    {
        var categoryImages = new Dictionary<string, string>();
        categoryImages.Add("Tropical", "ee9e2a40-ffac-4db9-9080-b351efc3cfc4.jpg");
        categoryImages.Add("Castles","1b6a8b70-a3b6-48b5-88e1-2243d9172c06.jpg");
        categoryImages.Add("Amazing Pools", "3fb523a0-b622-4368-8142-b5e03df7549b.jpg");
        categoryImages.Add("Caves",  "4221e293-4770-4ea8-a4fa-9972158d4004.jpg");
        categoryImages.Add("Minsus", "48b55f09-f51c-4ff5-b2c6-7f6bd4d1e049.jpg");
        categoryImages.Add("Surfing", "957f8022-dfd7-426c-99fd-77ed792f6d7a.jpg" );
        categoryImages.Add("Tiny Homes", "3271df99-f071-4ecf-9128-eb2d2b1f50f0.jpg");
        categoryImages.Add("Arctic", "8b44f770-7156-4c7b-b4d3-d92549c8652f.jpg");
        categoryImages.Add("Towers", "d721318f-4752-417d-b4fa-77da3cbc3269.jpg");
        categoryImages.Add("Islands", "8e507f16-4943-4be9-b707-59bd38d56309.jpg");
        categoryImages.Add("OMG!", "c5a4f6fc-c92c-4ae8-87dd-57f1ff1b89a6.jpg");
        categoryImages.Add("Amazing Views", "c5a4f6fc-c92c-4ae8-87dd-57f1ff1b89a6.jpg");
        categoryImages.Add("Bed & breakfasts", "5ed8f7c7-2e1f-43a8-9a39-4edfc81a3325.jpg");
        categoryImages.Add("Golfing", "6b639c8d-cf9b-41fb-91a0-91af9d7677cc.jpg");
        categoryImages.Add("Luxe", "c8e2ed05-c666-47b6-99fc-4cb6edcde6b4.jpg");
        categoryImages.Add("Camping", "ca25c7f3-0d1f-432b-9efa-b9f5dc6d8770.jpg");
        categoryImages.Add("Top of the world", "6b639c8d-cf9b-41fb-91a0-91af9d7677cc.jpg");
        
        foreach (var category in categoryImages)
        {
            await locationsDbContext.LocationCategories.AddAsync(new LocationCategory()
            {
                Name = category.Key,
                ImageUrl = category.Value
            });
        }

        await locationsDbContext.SaveChangesAsync();
    }

}