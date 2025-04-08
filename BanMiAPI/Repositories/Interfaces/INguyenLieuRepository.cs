using BanMiAPI.Models;

namespace BanMiAPI.Repositories.Interfaces
{
    public interface INguyenLieuRepository
    {
        Task<IEnumerable<NguyenLieu>> GetAll();
        Task<NguyenLieu?> GetById(int id);
        Task<int> Create(NguyenLieu nl);
        Task<bool> Update(NguyenLieu nl);
        Task<bool> Delete(int id);
    }
}
