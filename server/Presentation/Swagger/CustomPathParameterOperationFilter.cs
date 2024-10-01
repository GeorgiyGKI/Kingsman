using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

public class CustomPathParameterOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var parameter = operation.Parameters.FirstOrDefault(p => p.Name == "ids");
        if (parameter != null)
        {
            parameter.In = ParameterLocation.Path;
            parameter.Schema = new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("1,2")
            };
        }
    }
}
