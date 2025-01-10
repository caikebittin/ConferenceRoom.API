using ConferenceRoom.Core.Interfaces;
using System.Data;

namespace ConferenceRoom.Infra.Repositories;
public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly IDbConnection _connection;
    protected readonly string _tableName;

    protected BaseRepository(IConfiguration configuration, string tableName)
    {
        _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _tableName = tableName;
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        var query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
        return await _connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var query = $"SELECT * FROM {_tableName}";
        return await _connection.QueryAsync<T>(query);
    }

    public virtual async Task<Guid> AddAsync(T entity)
    {
        var columns = string.Join(", ", GetProperties());
        var parameters = string.Join(", ", GetProperties().Select(p => "@" + p));
        var query = $"INSERT INTO {_tableName} ({columns}) VALUES ({parameters}); SELECT CAST(SCOPE_IDENTITY() as uniqueidentifier)";

        return await _connection.ExecuteScalarAsync<Guid>(query, entity);
    }

    private IEnumerable<string> GetProperties()
    {
        return typeof(T).GetProperties()
            .Where(p => p.Name != "Id")
            .Select(p => p.Name);
    }
}
