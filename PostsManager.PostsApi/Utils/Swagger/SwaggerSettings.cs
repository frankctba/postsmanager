using Microsoft.OpenApi.Models;

namespace PostsManager.PostsApi.Utils.Swagger
{
    public class SwaggerSettings
    {
        public SwaggerSettings()
        {
            Name = "REST API Name";
            Info = new OpenApiInfo
            {
                Title = "REST API Title",
                Description = "REST API Description",
                Contact = new OpenApiContact
                {
                    Name = "REST API Contact Name",
                    Email = "contact@email.com"
                }
            };
        }

        /// <summary>
        /// Gets or sets document Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets swagger Info.
        /// </summary>
        public OpenApiInfo Info { get; set; }

        /// <summary>
        /// Gets or sets RoutePrefix.
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// Gets Route Prefix with tailing slash.
        /// </summary>
        public string RoutePrefixWithSlash =>
            string.IsNullOrWhiteSpace(RoutePrefix)
                ? string.Empty
                : RoutePrefix + "/";
    }
}
