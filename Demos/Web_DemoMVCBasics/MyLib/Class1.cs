using Microsoft.Extensions.Configuration;
using System.Text;

namespace MyLib
{
    public class Class1
    {
        private readonly IConfiguration _configuration;
        public Class1(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"logger: {_configuration["logger"]}");
            sb.AppendLine($"ComplexConfig.Name: {_configuration["ComplexConfig:Name"]}, ComplexConfig.Value: {_configuration["ComplexConfig:Value"]}");
            sb.AppendLine($"ComplexConfig.NestedProperty.Name: {_configuration["ComplexConfig:NestedProperty:Name"]}, ComplexConfig.NestedProperty.Value: {_configuration["ComplexConfig:NestedProperty:Value"]}");
            sb.AppendLine($"ArrayProperty[0].Name: {_configuration["ArrayProperty:0:Name"]}, ArrayProperty[0].Value: {_configuration["ArrayProperty:0:Value"]}");
            sb.AppendLine($"ArrayProperty[1].Name: {_configuration["ArrayProperty:1:Name"]}, ArrayProperty[1].Value: {_configuration["ArrayProperty:1:Value"]}");
            return sb.ToString();
        }
    }
}
