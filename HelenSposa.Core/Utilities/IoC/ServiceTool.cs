using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.IoC
{

    public static class ServiceTool
    {

        public static IServiceProvider ServiceProvider{ get; set; }

        //zaten microsoftun sagladigi ServiceCollaction nesnesine erisiyoruz ilavelerimi onun uzerine yapicaz

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
