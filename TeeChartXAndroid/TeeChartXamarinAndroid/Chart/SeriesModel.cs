using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using TeeChartXamarinAndroid.Chart;
using TeeChartXamarinAndroid.Enums;

namespace TeeChartXamarinAndroid.TeeChart
{
    public class SeriesModel
    {

        private TChart _tChart;
        private ChartTypeEnum _chartType;

        public SeriesModel() : this(new ChartView(default(ChartGroupEnum), default(ChartTypeEnum)).TChart, default(ChartGroupEnum), default(ChartTypeEnum)) { }
        public SeriesModel(TChart chart, ChartGroupEnum chartGroup, ChartTypeEnum chartType)
        {
            _chartType = chartType;
            _tChart = chart;
            InitializeChartView();
            InitializeSeries();
        }

        private void InitializeChartView()
        {
            _tChart.LayoutParameters = new ViewGroup.LayoutParams(200, 200);
            _tChart.LayoutParameters.Width = ViewGroup.LayoutParams.MatchParent;
            _tChart.LayoutParameters.Height = ViewGroup.LayoutParams.MatchParent;
            _tChart.SetBackgroundColor(Android.Graphics.Color.Red);
        }

        private void InitializeSeries()
        {
            switch(_chartType)
            {
                case ChartTypeEnum.Line:
                    CreateLineSeries();
                    break;
                case ChartTypeEnum.ColumnBar:
                    CreateColumnBarSeries();
                    break;
            }
        }

        #region SERIES

        #region STANDARD CHARTS

        private void CreateLineSeries()
        {
            InitLineChart();
        }

        private void CreateColumnBarSeries()
        {
            Bar bar1 = new Bar(_tChart.Chart);
            bar1.FillSampleValues();
        }

        #endregion

        #endregion

        
        private void InitLineChart()
        {
            Line line1 = new Line(_tChart.Chart);
            Line line2 = new Line(_tChart.Chart);

            // Chart Properties
            _tChart.Chart.Legend.Visible = true;
            _tChart.Chart.Header.Text = "Deaths and Births in Spain";

            // Line Properties
            line1.FillSampleValues();
            line2.FillSampleValues();

            line1.LinePen.Width = 6;
            line1.Pointer.InflateMargins = true;
            line1.Pointer.Visible = true;
            line1.Pointer.HorizSize = 11;
            line1.Pointer.VertSize = 11;
            line1.Pointer.Pen.EndCap = Android.Graphics.Paint.Cap.Round;
            line1.Pointer.Pen.Color = Color.White;
            line1.Pointer.Pen.Width = 5;
            line1.Pointer.Style = PointerStyles.Sphere;
            line1.Chart.Zoom.Direction = ZoomDirections.Both;
            line1.Chart.Panning.Allow = ScrollModes.None;
            line1.LineHeight = 25;
            line1.ClickableLine = true;
            line1.ClickTolerance = 30;
            line1.RecalcOptions = RecalcOptions.OnModify;
            line1.Title = "Births";
            line1.DefaultNullValue = 0;
            line1.VertAxis = VerticalAxis.Both;
            line1.HorizAxis = HorizontalAxis.Both;

            //line2.LinePen = new ChartPen { Width = 6, Color = var.GetPaletteBasic[1], };
            //line2.Pointer = new SeriesPointer(tChart.Chart, line2) { Color = var.GetPaletteBasic[1], InflateMargins = true, HorizSize = 11, VertSize = 11, Pen = new ChartPen { EndCap = PenLineCap.Round, Color = Xamarin.Forms.Color.White, Width = 5 }, Style = PointerStyles.Sphere };
            //line2.SeriesColor = var.GetPaletteBasic[1];
            line2.Chart.Zoom.Direction = ZoomDirections.Both;
            line2.Chart.Panning.Allow = ScrollModes.None;
            line2.LineHeight = 25;
            line2.ClickableLine = true;
            line2.ClickTolerance = 30;
            line2.RecalcOptions = RecalcOptions.OnModify;
            line2.Title = "Deaths";
            line2.VertAxis = VerticalAxis.Both;
            line2.HorizAxis = HorizontalAxis.Both;

            // Características de los ejes del "Chart" base
            _tChart.Chart.Axes.Left.SetMinMax(_tChart.Chart.Axes.Left.MinYValue - 10, _tChart.Chart.Axes.Left.MaxYValue + 10);
            _tChart.Chart.Axes.Bottom.SetMinMax(_tChart.Chart.Axes.Bottom.MinXValue, _tChart.Chart.Axes.Bottom.MaxXValue);
            _tChart.Chart.Axes.Left.Labels.ValueFormat = "0K";
            _tChart.Chart.Axes.Bottom.Labels.ValueFormat = "0";
            _tChart.Chart.Axes.Bottom.Increment = 1;
            _tChart.Chart.Axes.Left.Increment = 10;
            _tChart.Chart.Axes.Left.Visible = true;
            _tChart.Chart.Axes.Left.Title = null;
            _tChart.Chart.Axes.Bottom.Title = null;
            _tChart.Chart.Axes.Left.AxisPen.Visible = false;
            _tChart.Chart.Axes.Left.Ticks.Visible = false;
            _tChart.Chart.Axes.Left.Grid.Visible = true;
            _tChart.Chart.Legend.LegendStyle = LegendStyles.Series;
            _tChart.Chart.Axes.Bottom.Grid.Visible = false;
            _tChart.Chart.Panel.MarginLeft = 5;

        }
        
    }
}