using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<DbConnection>(_ =>
        {
            var connectionString = builder.GetContext().Configuration.GetValue<string>("SqlConnectionString");
            return new SqlConnection(connectionString);
        });

        builder.Services.AddScoped<IDataService, DataService>();
    }
}