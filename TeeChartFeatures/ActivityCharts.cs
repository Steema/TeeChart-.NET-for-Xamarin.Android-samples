using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TeeChartXamarinAndroid.Fragments;

namespace TeeChartXamarinAndroid
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class ActivityCharts : AppCompatActivity
    {

        Android.Support.Design.Widget.TabLayout tabLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_display_chart);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            ViewPagerAdapter viewPagerAdapter = new ViewPagerAdapter(SupportFragmentManager);
            viewPager.Adapter = viewPagerAdapter;

            tabLayout = (Android.Support.Design.Widget.TabLayout)FindViewById(Resource.Id.tabLayout);
            tabLayout.SetupWithViewPager(viewPager);

            Window.SetStatusBarColor(Utils.GetResources.GetColor(this, Resource.Color.colorPrimaryOver));

            FloatingActionButton floatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.floatButtonBot);
            floatingActionButton.Click += FloatingActionButton_Click;

        }

        private void FloatingActionButton_Click(object sender, EventArgs e)
        {
            BottomNavigationDrawerFragment bottomNavDrawerFragment = new BottomNavigationDrawerFragment();
            bottomNavDrawerFragment.Show(SupportFragmentManager, bottomNavDrawerFragment.Tag);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) { OnBackPressed(); return true; }
            return base.OnOptionsItemSelected(item);
        }


        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

    }

    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        private string[] _titles;
        Android.Support.V4.App.FragmentManager _fragmentManager;
        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager fragmentManager) : base(fragmentManager)
        {
            _titles = new string[13] {"Line", "Column Bar", "Area", "Pie", "Fast Line", "Horizontal Area", "Horizontal Bar", "Horizontal Line", "Donut", "Bubble", "Grantt", "Shape", "Point/Scatter" };
            _fragmentManager = fragmentManager;
        }
        public override int Count => _titles.Length;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            Android.Support.V4.App.Fragment fragment = Fragments.TabChartFragment.GetInstance(position);
            return fragment;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            ICharSequence text = new Java.Lang.String(_titles[position]);
            return text;
        }

    }

}