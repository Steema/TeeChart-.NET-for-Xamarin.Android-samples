
using Android.App;
using Android.OS;

namespace MonoAndroidDemo
{
	[Activity (Label = "ListItem")]			
	public class ListItem : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

      SetContentView(Resource.Layout.ListItem);

      //var seriesAdapter = new SeriesAdapter(this); 
      //var listView = FindViewById<ListView>(Resource.Id.seriesListView);
      //listView.Adapter = seriesAdapter;
		}
	}
}

