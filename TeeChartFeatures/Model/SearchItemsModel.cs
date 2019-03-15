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

namespace TeeChartXamarinAndroid.Model
{
    public class SearchItemsModel
    {

        private string _name;
        private int _image;

        public SearchItemsModel() { }

        public SearchItemsModel(string name, int image)
        {
            _name = name;
            _image = image;
        }

        public string Name { get => _name; set => _name = value; }
        public int Image { get => _image; set => _image = value; }

    }
}