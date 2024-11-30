using CloudinaryDotNet;

namespace Examify.UploadFile.Infrastructure.Cloudinary;

public static class Extensions
{
    public static IServiceCollection AddCloudinary(this IServiceCollection services, IConfiguration configuration)
    {
        var cloudinaryOptions = configuration.GetSection("CloudinaryOptions").Get<CloudinaryOptions>();

        var cloudinary = new CloudinaryDotNet.Cloudinary(new Account(
            cloudinaryOptions.CloudName,
            cloudinaryOptions.ApiKey,
            cloudinaryOptions.ApiSecret
        ));
        
        services.AddSingleton(cloudinary);
        return services;
    }
}