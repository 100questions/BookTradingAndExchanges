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
        List<HOADON_DTO> lstHoaDon;
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

        public async void Load() {
            lstHoaDon = await hoadon_ctl.GetList();
            cbbFillter.ItemsSource = new string[] {"2018","2019","2020","2021" };
        }

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
