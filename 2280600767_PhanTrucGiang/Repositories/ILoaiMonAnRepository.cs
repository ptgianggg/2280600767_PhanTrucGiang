using _2280600767_PhanTrucGiang.Models;
using System.Collections.Generic;

namespace _2280600767_PhanTrucGiang.Repositories
{
    public interface ILoaiMonAnRepository
    {
        List<LoaiMonAn> GetAllLoaiMonAn();
        LoaiMonAn GetLoaiMonAnById(string id);
        void AddLoaiMonAn(LoaiMonAn loaiMonAn);
        void UpdateLoaiMonAn(LoaiMonAn loaiMonAn);
        void DeleteLoaiMonAn(string id);
    }
}
