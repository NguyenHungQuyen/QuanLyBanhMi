using Dapper;
using BanMiAPI.Data;
using BanMiAPI.Models;
using BanMiAPI.Repositories.Interfaces;

namespace BanMiAPI.Repositories
{
    public class NguyenLieuRepository : INguyenLieuRepository
    {
        private readonly DbContext _context;

        public NguyenLieuRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NguyenLieu>> GetAll()
        {
            var query = "SELECT * FROM NguyenLieu";
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<NguyenLieu>(query);
        }

        public async Task<NguyenLieu?> GetById(int id)
        {
            var query = "SELECT * FROM NguyenLieu WHERE Id = @Id";
            using var conn = _context.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<NguyenLieu>(query, new { Id = id });
        }

        public async Task<int> Create(NguyenLieu nl)
        {
            var query = @"INSERT INTO NguyenLieu (Ten, DonVi, SoLuongTon) 
                          VALUES (@Ten, @DonVi, @SoLuongTon);
                          SELECT CAST(SCOPE_IDENTITY() as int)";
            using var conn = _context.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(query, nl);
        }

        public async Task<bool> Update(NguyenLieu nl)
        {
            var query = @"UPDATE NguyenLieu SET Ten = @Ten, DonVi = @DonVi, SoLuongTon = @SoLuongTon WHERE Id = @Id";
            using var conn = _context.CreateConnection();
            var rows = await conn.ExecuteAsync(query, nl);
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var query = "DELETE FROM NguyenLieu WHERE Id = @Id";
            using var conn = _context.CreateConnection();
            var rows = await conn.ExecuteAsync(query, new { Id = id });
            return rows > 0;
        }
    }
}
