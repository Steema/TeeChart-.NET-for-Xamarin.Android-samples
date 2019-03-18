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

namespace TeeChartXamarinAndroid.Fragments
{
    public class BottomNavigationDrawerFragment : Android.Support.Design.Widget.BottomSheetDialogFragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_bottom_sheet, container, false);
        }

    }
}