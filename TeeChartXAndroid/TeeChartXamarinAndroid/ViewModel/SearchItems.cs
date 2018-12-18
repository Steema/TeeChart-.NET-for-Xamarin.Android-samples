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

namespace TeeChartXamarinAndroid.ViewModel
{

    public class SearchItems
    {

        private List<SearchItemsModel> _items;
        private Context _context;

        public SearchItems(Context context, List<SearchItemsModel> items)
        {
            _context = context;
            _items = items;
        }

        public List<SearchItemsModel> Items { get => _items; set => _items = value; }

        public int ItemsCount { get => _items.Count; }

    }
}