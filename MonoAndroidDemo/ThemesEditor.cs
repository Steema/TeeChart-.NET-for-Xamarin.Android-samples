using System;

using Android.App;
using Android.Content;
using Android.Widget;
using Steema.TeeChart;
using Steema.TeeChart.Themes;

namespace MonoAndroidDemo
{
  class ThemesEditor
  {
    Chart chart;
	  int selected;
    string[] themes;

	  public ThemesEditor(Chart chart, int selected) 
    {
      this.chart = chart.Chart;
      this.selected = selected;
      themes = Enum.GetNames(typeof(ThemeType));
	  }

    public void Choose(Context context) 
    {
      var builder = new AlertDialog.Builder(context)
          .SetTitle("Select Theme")
          .SetPositiveButton(Android.Resource.String.Ok, delegate
            {
              Toast
                .MakeText(context, themes[selected], ToastLength.Short)
                .Show();
              chart.Parent.SetCurrentThemeType((ThemeType)selected);
            })
            .SetNegativeButton(Android.Resource.String.Cancel, CancelClicked);

      builder.SetSingleChoiceItems(themes, selected, (sender, args) =>
            {
              selected = args.Which;          
            });

      builder.Create().Show();
    }

    void CancelClicked(object sender, DialogClickEventArgs e)
    {
    }
  }
}