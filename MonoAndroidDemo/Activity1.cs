using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace MonoAndroidDemo
{
  [Activity(Name = "com.steema.teechart.xamarin.android.Activity1", Label = "Xamarin.Android Demo", MainLauncher = true, Icon = "@drawable/icon")]
  public class Activity1 : BaseActivity
  {
    protected override int LayoutResource
    {
      get
      {
        return Resource.Layout.Main;
      }
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      SupportActionBar.Title = "TeeChart for Xamarin.Android Demo";
      SupportActionBar.SetDisplayHomeAsUpEnabled(false);
      SupportActionBar.SetHomeButtonEnabled(false);

      var seriesAdapter = new SeriesAdapter(this);
      var seriesListView = FindViewById<ListView>(Resource.Id.seriesListView);
      seriesListView.DrawingCacheEnabled = false;
      seriesListView.Adapter = seriesAdapter;
      //seriesListView.ItemClick += new EventHandler<ItemEventArgs>(seriesListView_ItemClick); //4.0.6
      seriesListView.ItemClick += seriesListView_ItemClick;  //4.1.1
    }

    //void seriesListView_ItemClick(object sender, ItemEventArgs e) //4.0.6
    void seriesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)  //4.1.1
    {      
      var myIntent = new Intent(e.View.Context, typeof(ChartView));
		  myIntent.PutExtra("SeriesPosition", e.Position);
      StartActivityForResult(myIntent, 1);      
    }

  }
}

