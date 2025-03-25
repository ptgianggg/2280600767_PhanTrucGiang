using _2280600767_PhanTrucGiang.Models;

public interface IMonAnRepository
{
    Task<IEnumerable<MonAn>> GetAllAsync();
    Task<MonAn> GetByIdAsync(string id); // Thay đổi kiểu dữ liệu của id thành string
    List<MonAn> LayDSMonAn();
    List<MonAn> SuaMonAn(MonAn monAn);
    List<MonAn> ThemMonAn(MonAn monAn);
    List<MonAn> XoaMonAn(MonAn monAn);
}

