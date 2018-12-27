using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace TeeChartXamarinAndroid.Fragments
{
    public class BottomNavigationDrawerFragment : BottomSheetDialogFragment
    {

        public static BottomSheetDialogFragment NewInstance()
        {
            Bundle bundle = new Bundle();
            BottomSheetDialogFragment fragmentBottomSheet = new BottomNavigationDrawerFragment();
            fragmentBottomSheet.Arguments = bundle;
            return fragmentBottomSheet;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LinearLayout layout = (LinearLayout)LayoutInflater.Inflate(Resource.Layout.fragment_bottom_sheet, container, false);
            return layout;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
        }

    }
}