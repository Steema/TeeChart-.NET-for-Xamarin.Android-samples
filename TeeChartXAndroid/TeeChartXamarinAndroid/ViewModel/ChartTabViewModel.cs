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
using TeeChartXamarinAndroid.Enums;
using TeeChartXamarinAndroid.Model;

namespace TeeChartXamarinAndroid.ViewModel
{
    public class ChartTabViewModel
    {

        private List<ChartTabModel> _chartTabModels;
        private string _titleGroup;

        public ChartTabViewModel(ChartGroupEnum chartGroup)
        {
            switch(chartGroup)
            {
                case ChartGroupEnum.StandardCharts:
                    _chartTabModels = new List<ChartTabModel>()
                    {
                        new ChartTabModel(chartGroup, ChartTypeEnum.Line),
                        new ChartTabModel(chartGroup, ChartTypeEnum.ColumnBar),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Area),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Pie),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.FastLine),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.HorizontalArea),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.HorizontalBar),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.HorizontalLine),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Donut),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Bubble),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Gantt),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.Shape),
                        //new ChartTabModel(chartGroup, ChartTypeEnum.PointScatter)
                    };
                    _titleGroup = "Standard Charts";
                    break;
                case ChartGroupEnum.ProCharts:
                    break;
                case ChartGroupEnum.CircularGauge:
                    break;
                case ChartGroupEnum.Maps:
                    break;
                case ChartGroupEnum.TreeMap:
                    break;
                case ChartGroupEnum.KnobGauge:
                    break;
                case ChartGroupEnum.Clock:
                    break;
                case ChartGroupEnum.Organizational:
                    break;
                case ChartGroupEnum.NumericGauge:
                    break;
                case ChartGroupEnum.LinearGauge:
                    break;
                case ChartGroupEnum.Calendar:
                    break;
                case ChartGroupEnum.TagCloud:
                    break;
            }
        }

        public List<ChartTabModel> Items => _chartTabModels;
        public ChartTabModel this[int index]
        {
            get
            {
                return Items[index];
            }
        } 
        public int Count => _chartTabModels.Count;
        public String TitleGroup => _titleGroup;

    }
}