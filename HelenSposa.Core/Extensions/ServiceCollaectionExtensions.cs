using HelenSposa.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Extensions
{
    public static class ServiceCollaectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
