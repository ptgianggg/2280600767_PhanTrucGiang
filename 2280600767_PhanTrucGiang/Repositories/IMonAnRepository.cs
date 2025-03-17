using _2280600767_PhanTrucGiang.Models;

namespace _2280600767_PhanTrucGiang.Repositories
{
    public interface IMonAnRepository
    {

        List<MonAn> LayDSMonAn();
        List<MonAn> SuaMonAn(MonAn monAn);
        List<MonAn> ThemMonAn(MonAn monAn);
        List<MonAn> XoaMonAn(MonAn monAn);

    }
}
