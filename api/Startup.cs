using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<DbConnection>((s) =>
        {
            // Connection string should be stored securely, e.g., in Azure Key Vault or App Settings
            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            return new SqlConnection(connectionString);
        });

        builder.Services.AddScoped<IDataService, DataService>();
    }
}