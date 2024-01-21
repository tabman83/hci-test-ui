using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;

namespace Api;

public interface IDataService
{
    Task<ResultOrError<Patient, Exception>> FindPatientAsync(string name,
        CancellationToken cancellationToken = default);
    Task<ResultOrError<IEnumerable<Visit>, Exception>> GetVisitsAsync(Guid patientId,
        CancellationToken cancellationToken = default);
}

public class DataService : IDataService
{
    private readonly DbConnection _dbConnection;

    public DataService(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ResultOrError<Patient, Exception>> FindPatientAsync(string name, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbConnection.OpenAsync(cancellationToken);
            await using var command = _dbConnection.CreateCommand();
            command.CommandText =
                "SELECT * FROM Patients WHERE Name LIKE @SearchPattern";
            command.Parameters.Add(new SqlParameter("@SearchPattern", SqlDbType.NVarChar)
                { Value = $"{name}%" });
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            if (reader.HasRows)
            {
                await reader.ReadAsync(cancellationToken);
                var result = Patient.FromReader(reader);
                return ResultOrError<Patient, Exception>.WithSuccess(result);
            }

            return ResultOrError<Patient, Exception>.WithError(new InvalidOperationException("NotFound"));
        }
        catch (Exception exception)
        {
            return ResultOrError<Patient, Exception>.WithError(exception);
        }
        finally
        {
            await _dbConnection.CloseAsync();
        }
    }

    public async Task<ResultOrError<IEnumerable<Visit>, Exception>> GetVisitsAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbConnection.OpenAsync(cancellationToken);
            await using var command = _dbConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Visits WHERE PatientId = @PatientId";
            command.Parameters.Add(new SqlParameter("@PatientId", SqlDbType.UniqueIdentifier) { Value = patientId });
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            var result = new List<Visit>();
            while (await reader.ReadAsync(cancellationToken))
            {
                var visit = Visit.FromReader(reader);
                result.Add(visit);
            }

            return ResultOrError<IEnumerable<Visit>, Exception>.WithSuccess(result);
        }
        catch (Exception exception)
        {
            return ResultOrError<IEnumerable<Visit>, Exception>.WithError(exception);
        }
        finally
        {
            await _dbConnection.CloseAsync();
        }
    }
}
