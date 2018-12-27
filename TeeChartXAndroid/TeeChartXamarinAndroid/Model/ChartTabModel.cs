using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TeeChartXamarinAndroid.Chart;
using TeeChartXamarinAndroid.Enums;

namespace TeeChartXamarinAndroid.Model
{
    public class ChartTabModel : Java.Lang.Object, Java.IO.ISerializable
    {

        private ChartGroupEnum _chartGroup;
        private ChartTypeEnum _chartType;
        private Steema.TeeChart.TChart _tChart;
        private string _title;

        public ChartTabModel() : this(default(ChartGroupEnum), default(ChartTypeEnum)) { }
        public ChartTabModel(ChartGroupEnum chartGroup, ChartTypeEnum chartType)
        {
            _chartGroup = chartGroup;
            _chartType = chartType;
            _tChart = new ChartView(chartGroup, chartType).TChart;
            SetInternalTitle();
        }

        private void SetInternalTitle()
        {
            switch(_chartType)
            {
                case ChartTypeEnum.Line:
                    _title = "Line";
                    break;
                case ChartTypeEnum.ColumnBar:
                    _title = "Bar";
                    break;
            }
        }

        public ChartGroupEnum ChartGroup => _chartGroup;
        public ChartTypeEnum ChartType => _chartType;
        public Steema.TeeChart.TChart TChart => _tChart;
        public String Title => _title;

    }
}