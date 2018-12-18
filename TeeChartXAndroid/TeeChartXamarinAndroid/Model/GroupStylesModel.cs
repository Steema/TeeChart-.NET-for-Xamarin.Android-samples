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
    public class GroupStylesModel
    {

        private int _imageId;
        private string _title;
        private string _description;
		
		public GroupStylesModel() {}
		public GroupStylesModel(int imageId, string title, string description) {
			
			_imageId = imageId;
			_title = title;
			_description = description;
			
		}

        public int Image { set => _imageId = value; get => _imageId; }
        public string Title { set => _title = value; get => _title; }
        public string Description { set => _description = value; get => _description; }

    }
}