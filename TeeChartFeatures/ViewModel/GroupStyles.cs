using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TeeChartXamarinAndroid.Model;
using TeeChartXamarinAndroid.Utils;

namespace TeeChartXamarinAndroid.ViewModel
{
    public class GroupStyles
    {

        private GroupStylesModel[] _items;

        public GroupStyles()
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
            _items = new GroupStylesModel[] {
                new GroupStylesModel(Resource.Drawable.groupstyles_bar, Application.Context.GetString(Resource.String.titleStdCharts), GetResources.GetString(Resource.String.descriptStdCharts)),
                new GroupStylesModel(Resource.Drawable.groupstyles_tower, Application.Context.GetString(Resource.String.titleProCharts), GetResources.GetString(Resource.String.descriptProCharts)),
                new GroupStylesModel(Resource.Drawable.groupstyles_circulargauge, Application.Context.GetString(Resource.String.titleCircularGauge), GetResources.GetString(Resource.String.descriptCircularGauge)),
                new GroupStylesModel(Resource.Drawable.groupstyles_map, Application.Context.GetString(Resource.String.titleMaps), GetResources.GetString(Resource.String.descriptMaps)),
                new GroupStylesModel(Resource.Drawable.groupstyles_renko, Application.Context.GetString(Resource.String.titleTreeMap), GetResources.GetString(Resource.String.descriptTreeMap)),
                new GroupStylesModel(Resource.Drawable.groupstyles_knobgauge, Application.Context.GetString(Resource.String.titleKnobGauge), GetResources.GetString(Resource.String.descriptKnobGauge)),
                new GroupStylesModel(Resource.Drawable.groupstyles_clock, Application.Context.GetString(Resource.String.titleClock), GetResources.GetString(Resource.String.descriptClock)),
                new GroupStylesModel(Resource.Drawable.groupstyles_org, Application.Context.GetString(Resource.String.titleOrganizational), GetResources.GetString(Resource.String.descriptOrganizational)),
                new GroupStylesModel(Resource.Drawable.groupstyles_numericgauge, Application.Context.GetString(Resource.String.titleNumericGauge), GetResources.GetString(Resource.String.descriptNumericGauge)),
                new GroupStylesModel(Resource.Drawable.groupstyles_lineargauge, Application.Context.GetString(Resource.String.titleLinearGauge), GetResources.GetString(Resource.String.descriptLinearGauge)),
                new GroupStylesModel(Resource.Drawable.groupstyles_calendar, Application.Context.GetString(Resource.String.titleCalendar), GetResources.GetString(Resource.String.descriptCalendar)),
                new GroupStylesModel(Resource.Drawable.groupstyles_tagcloud, Application.Context.GetString(Resource.String.titleTagCloud), GetResources.GetString(Resource.String.descriptTagCloud)),
                new GroupStylesModel(Resource.Drawable.groupstyles_kagi, Application.Context.GetString(Resource.String.titleStdFunctions), GetResources.GetString(Resource.String.descriptStdFunctions)),
                new GroupStylesModel(Resource.Drawable.groupstyles_ternary, Application.Context.GetString(Resource.String.titleProFunctions), GetResources.GetString(Resource.String.descriptProFunctions)),
            };
        }

        public GroupStylesModel[] Items { get => _items; }

    }
}