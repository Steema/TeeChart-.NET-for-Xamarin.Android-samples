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

	  String[] themes = new String[Theme.ChartThemes.Count];

	  public ThemesEditor(Chart chart, int selected) 
    {
      this.chart = chart.Chart;
      this.selected = selected;

      for (int t = 0; t < themes.Length; t++)
      {
        themes[t] = Theme.ChartThemes[t].Name; //ThemesList.getThemeDescription(t);
      }
	  }

    public void Choose(Context context) 
    {
      AlertDialog.Builder builder = new AlertDialog.Builder(context)
          .SetTitle("Select Theme")
          .SetPositiveButton(Android.Resource.String.Ok, delegate
            {
              Toast
                .MakeText(context, themes[selected], ToastLength.Short)
                .Show();

              var tmpTheme = (Theme)Activator.CreateInstance(Theme.ChartThemes[selected]);
              tmpTheme.Apply(chart);
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