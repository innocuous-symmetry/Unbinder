namespace Unbinder.Services
{
    public static class EnvironmentLoader
    {
        public static void Load(WebApplicationBuilder builder)
        {
            Environment.SetEnvironmentVariable("AWS_S3_URL", builder.Configuration["AWS_S3_URL"]);
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY", builder.Configuration["AWS_ACCESS_KEY"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_KEY", builder.Configuration["AWS_SECRET_KEY"]);
            Environment.SetEnvironmentVariable("AWS_BUCKET_NAME", builder.Configuration["AWS_BUCKET_NAME"]);
        }
    }
}
