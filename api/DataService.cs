using System.Data.Common;
using System.Threading.Tasks;

namespace api;

public interface IDataService
{
    Task<string> GetDataAsync();
}

public class DataService : IDataService
{
    private readonly DbConnection _dbConnection;

    public DataService(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<string> GetDataAsync()
    {
        // Implement your data retrieval logic here
        // Example: Execute a SQL query and return results
        _dbConnection.Open();
        using var command = _dbConnection.CreateCommand();
        command.CommandText = "SELECT TOP 1 * FROM YourTable";
        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return reader["YourColumn"].ToString();
        }
        return null;
    }
}
