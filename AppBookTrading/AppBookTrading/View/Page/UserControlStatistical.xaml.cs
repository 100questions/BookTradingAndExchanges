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

namespace AppBookTrading.View.Page
{
    /// <summary>
    /// Interaction logic for UserControlStatistical.xaml
    /// </summary>
    public partial class UserControlStatistical : UserControl
    {
        public UserControlStatistical()
        {
            InitializeComponent();
            LoadAreaChartData();
        }

        private void LoadAreaChartData()
        {
            ((AreaSeries)mcChart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
        new KeyValuePair<string,int>("Jan 2009", 100),
        new KeyValuePair<string,int>("Apr 2009", 180),
        new KeyValuePair<string,int>("July 2009", 110),
        new KeyValuePair<string,int>("Oct 2009", 95),
        new KeyValuePair<string,int>("Jan 2010", 40),
        new KeyValuePair<string,int>("Apr 2010", 95)
            };
        }

    }
}
