using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace MinimalAPIWithDB.DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "default");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "default");
}

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }


}