using BanMiAPI.Data;
using Dapper;

public class BanhMiRepository
{
    private readonly DbContext _context;

    public BanhMiRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BanhMi>> GetAll()
    {
        var query = "SELECT * FROM BanhMi";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<BanhMi>(query);
    }

    public async Task<BanhMi?> GetById(int id)
    {
        var query = "SELECT * FROM BanhMi WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<BanhMi>(query, new { Id = id });
    }

    public async Task<int> Create(BanhMi banhMi)
    {
        var query = "INSERT INTO BanhMi (Ten, Gia) VALUES (@Ten, @Gia)";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(query, banhMi);
    }
}
