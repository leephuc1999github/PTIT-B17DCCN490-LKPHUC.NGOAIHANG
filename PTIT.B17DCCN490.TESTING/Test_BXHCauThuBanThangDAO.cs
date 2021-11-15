using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.TESTING
{
    [TestClass]
    public class Test_BXHCauThuBanThangDAO
    {
        private IBXHCauThuBanThangDAO _bxhCauThuBanThangDAO;
        private IBXHDAO _bxhDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._bxhCauThuBanThangDAO = new BXHCauThuBanThangDAO();
            this._bxhDAO = new BXHDAO();
        }

        #region Test kiểm tra với dữ liệu đầu vào
        /// <summary>
        /// Test mùa giải không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_BXHCauThuBanThangDAO_1()
        {
            Guid muaGiai = new Guid("3B801E54-65BC-4BBD-9DE6-65F87164F0AA");
            var actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(muaGiai);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Tồn tại giải đấu và không có trận đấu nào
        /// </summary>
        [TestMethod]
        public void Test_BXHCauThuBanThangDAO_2()
        {
            Guid muaGiai = new Guid("96259187-435e-11ec-92b4-f01faf56e08c");
            var actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(muaGiai);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Tồn tại giải đấu và không có trận đấu nào đang kết thúc
        /// </summary>
        [TestMethod]
        public void Test_BXHCauThuBanThangDAO_3()
        {
            Guid muaGiai = new Guid("af13edf2-315c-11ec-8a5d-f01faf56e08c");
            var actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(muaGiai);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Tồn tại giải đấu, có trận đấu kết thúc
        /// </summary>
        [TestMethod]
        public void Test_BXHCauThuBanThangDAO_4()
        {
            // Tổng số bàn thắng từ đội bóng trận đấu
            // SELECT SUM(dt.SoBanThang) FROM doibong_trandau dt
            // INNER JOIN trandau t ON dt.TranDauId = t.Id AND t.VongDauId IN(SELECT v.Id FROM vongdau v WHERE v.GiaiDauId = '470dd012-7886-75fc-8186-fecdbcc4765c');

            // Tổng số bàn thắng từ sự kiện của giải
            //  SELECT COUNT(*) FROM sukien s WHERE s.LoaiSuKienId = '3c46f4ee-62ea-5c8d-986f-b9e6bde19f05'
            //AND s.CauThuDoiBongTranDauId IN(SELECT cdt.Id FROM cauthua_doibong_trandau cdt
            //INNER JOIN doibong_trandau dt ON cdt.DoiBongTranDauId = dt.Id
            //INNER JOIN trandau t ON dt.TranDauId = t.Id WHERE t.VongDauId IN (SELECT v.Id FROM vongdau v WHERE v.GiaiDauId = '470dd012-7886-75fc-8186-fecdbcc4765c'));

            Guid muaGiai = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(muaGiai);
            int tongSoBanThangActual = 0;

            // Bảng xếp hạng đội bóng chung cuộc
            var bxh = this._bxhDAO.GetTKBXH(muaGiai);
            for (int i = 0; i < actual.Count(); i++)
            {
                tongSoBanThangActual += actual[i].BanThang;
                // Kiểm tra có cầu thủ nào không tham gia đấu mà có bàn thắng không?
                Assert.IsTrue(actual[i].ThoiGian > 0);
                // Kiểm tra có cầu thủ nào không có bàn thắng mà xuất hiện trong bảng xếp hạng không?
                Assert.IsTrue(actual[i].BanThang > 0);

                string[] ten = actual[i].Ten.Split("|");
                // Kiểm tra thứ hạng đội bóng theo cầu thủ
                Assert.IsTrue(actual[i].ThuHang == bxh.Where(item => item.Ten.Equals(ten[1])).FirstOrDefault().ThuHang);

                if(i < actual.Count() - 1)
                {
                    // Kiểm tra sắp xếp 
                    Assert.IsTrue(actual[i].BanThang >= actual[i+1].BanThang);
                    if(actual[i].BanThang == actual[i + 1].BanThang) 
                        Assert.IsTrue(actual[i].KienTao >= actual[i+1].KienTao);
                    if(actual[i].BanThang == actual[i + 1].BanThang && actual[i].KienTao == actual[i + 1].KienTao) 
                        Assert.IsTrue( actual[i].ThuHang <= actual[i+1].ThuHang);
                    if(actual[i].BanThang == actual[i + 1].BanThang && actual[i].KienTao == actual[i + 1].KienTao && actual[i].ThuHang == actual[i + 1].ThuHang) 
                        Assert.IsTrue(actual[i].ThoiGian <= actual[i+1].ThoiGian);
                }
                
            }
            // Kiểm tra tổng số bàn thắng trong bảng thống kê và thực tế trong csdl
            Assert.AreEqual(366, tongSoBanThangActual);
        }
        #endregion
    }
}
