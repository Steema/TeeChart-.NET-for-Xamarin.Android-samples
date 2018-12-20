using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TeeChartXamarinAndroid.Fragments
{
    public class TabChartFragment : Android.Support.V4.App.Fragment
    {

        int position;
        private TextView textView;

        public static Android.Support.V4.App.Fragment GetInstance(int position)
        {
            Bundle bundle = new Bundle();
            bundle.PutInt("pos", position);
            TabChartFragment tabChartFragment = new TabChartFragment();
            tabChartFragment.Arguments = bundle;
            return tabChartFragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("pos");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.fragment_tab, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            textView = (TextView)view.FindViewById(Resource.Id.textView);
            textView.Text = "Fragment " + (position + 1);
        }

    }
}