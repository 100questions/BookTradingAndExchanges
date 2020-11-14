using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL_BLL_Tier;

namespace AppBookTrading.View.Page
{
    /// <summary>
    /// Interaction logic for UserControlStatistical.xaml
    /// </summary>
    public partial class UserControlStatistical : UserControl
    {
        Ctl_HoaDon hoadon_ctl = new Ctl_HoaDon();
        Ctl_Sach sach_ctl = new Ctl_Sach();
        List<HOADON_DTO> lstHoaDon;
        List<SACH_DTO> lstSach;
        private const string DANG_KINH_DOANH = "Đang kinh doanh";
        private const string HET_HANG = "Hết hàng";
        private const string NGUNG_KINH_DOANH = "Ngừng kinh doanh";
        public UserControlStatistical()
        {
            InitializeComponent();
            Load();
        }

        private void LoadAreaChartData()
        {
            ((AreaSeries)mcChart.Series[0]).ItemsSource = new KeyValuePair<string, double>[]
            {
                new KeyValuePair<string,double>("Jan 2009", 100),
                new KeyValuePair<string,double>("Apr 2009", 180),
                new KeyValuePair<string,double>("July 2009", 110),
                new KeyValuePair<string,double>("Oct 2009", 95),
                new KeyValuePair<string,double>("Jan 2010", 40),
                new KeyValuePair<string,double>("Apr 2010", 95)
            };
        }

        /// <summary>
        /// Load data
        /// </summary>
        public async void Load() {
            try
            {
                lstHoaDon = await hoadon_ctl.GetList();
                lstSach = await sach_ctl.GetList();
                int slSPDangKD = 0;
                int slSPHetHang = 0;
                int slSPNgungKD = 0;
                if (lstSach != null)
                {
                    lstSach.ForEach(s => {
                        if (s.TRANGTHAI == DANG_KINH_DOANH)
                        {
                            slSPDangKD++;
                        }
                        else if (s.TRANGTHAI == HET_HANG)
                        {
                            slSPHetHang++;
                        }
                        else
                        {
                            slSPNgungKD++;
                        }
                        
                    });
                    txtSanPhamNgungKD.Text = slSPNgungKD.ToString();
                    txtSanPhamHetHang.Text = slSPHetHang.ToString();
                    txtSanPhamDangKinhDoanh.Text = slSPDangKD.ToString();

                }
                cbbFillter.ItemsSource = new string[] { "2018", "2019", "2020", "2021" };
                double doanhThuThang = 0;
                double doanhThuNam = 0;
                int soDonTrongThang = 0;
                lstHoaDon.ForEach(hd =>
                {
                    if (hd.NGAYLAPHD.Value.Month == DateTime.Now.Month)
                    {
                        doanhThuThang += hd.THANHTIEN;
                        soDonTrongThang++;
                    }
                    if (hd.NGAYLAPHD.Value.Year == DateTime.Now.Year)
                    {
                        doanhThuNam += hd.THANHTIEN;
                    }
                });
                txtDoanhThuThang.Text = doanhThuThang.ToString();
                txtDoanhThuNam.Text = doanhThuNam.ToString();
                txtTongDonHang.Text = lstHoaDon.Count().ToString();
                txtDonHangTrongThang.Text = soDonTrongThang.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Loc thanh tien theo nam
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public Dictionary<string, double> FilterData(int year)
        {
            Dictionary<string, double> datas = new Dictionary<string, double>();
            if (lstHoaDon != null)
            {
                lstHoaDon.Where(s => s.NGAYLAPHD != null).Where(s => s.NGAYLAPHD.Value.Year == year).ToList().ForEach(t =>
                {
                    string month = t.NGAYLAPHD.Value.Month.ToString();
                    if (datas.ContainsKey(month))
                    {
                        datas[month] = datas[month] + t.THANHTIEN;

                    }
                    else
                    {
                        datas.Add(month, t.THANHTIEN);
                    }
                });
            }
            return datas;
        }

        private void cbbFillter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int year = Int32.Parse(cbbFillter.SelectedItem.ToString());
            if (year != null)
            {
                ((AreaSeries)mcChart.Series[0]).ItemsSource = FilterData(year);
            }
        }
    }
}
