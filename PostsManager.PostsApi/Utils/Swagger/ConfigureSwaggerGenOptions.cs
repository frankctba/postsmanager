using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PostsManager.PostsApi.Utils.Swagger
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerSettings _settings;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider, 
                                          IOptions<SwaggerSettings> swaggerSettings)
        {
            _provider = provider;
            _settings = swaggerSettings.Value ?? new SwaggerSettings();
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = _settings.Info.Title,
                Version = description.ApiVersion.ToString(),
                Description =_settings.Info.Description,
                Contact = new OpenApiContact()
                {
                    Name = _settings.Info.Contact.Name,
                    Email = _settings.Info.Contact.Email
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}