namespace NerdysoftWebAPI.Configurations;

public static class CORSConfiguration
{
    public static IApplicationBuilder UseCrossOriginResourceSharing(this IApplicationBuilder app)
    {
        return app.UseCors(x => x
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
    }
}
