using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TeeChartXamarinAndroid.ViewModel;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views.InputMethods;
using Java.Lang;
using TeeChartXamarinAndroid.Model;

namespace TeeChartXamarinAndroid
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class ActivitySearch : AppCompatActivity
    {

        private List<SearchItemsModel> _items;
        private SearchItems _searchViewModel;
        private SearchItemsAdapter _searchItemsAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_search);
            // Set statusBarColor
            Window.SetStatusBarColor(Utils.GetResources.GetColor(this, Resource.Color.colorPrimaryOver));
            // Get layoutManager, RecyclerViewer and initializeItems
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewSearch);
            _items = InitializeItems();
            _searchViewModel = new SearchItems(Application.Context, _items);
            // Set layoutManager and adapter
            recyclerView.SetLayoutManager(linearLayoutManager);
            _searchItemsAdapter = new SearchItemsAdapter(_searchViewModel);
            recyclerView.SetAdapter(_searchItemsAdapter);
            // BackButton click onBackButtonPressed
            ImageButton backButton = FindViewById<ImageButton>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;
            // ImageButton clear editText
            ImageButton cancelSearchButton = FindViewById<ImageButton>(Resource.Id.search_clear_text);
            cancelSearchButton.Click += CancelSearchButton_Click;
            // EditText search action
            EditText editText = FindViewById<EditText>(Resource.Id.edt_search_chart);
            editText.SetOnEditorActionListener(new ExtendOnEditorActionListener());
            editText.AddTextChangedListener(new ExtendOnTextChangedListener(_searchItemsAdapter, _items, cancelSearchButton));
            
        }


        /// <summary>
        /// Crea los items del recycler view
        /// </summary>
        /// <returns></returns>
        private List<SearchItemsModel> InitializeItems()
        {
            List<SearchItemsModel> items = new List<SearchItemsModel>()
            {
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.lineChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.columnbarChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.areaChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.pieChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.fstlineChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.hAreaChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.lineChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.lineChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.lineChartName), Resource.Drawable.groupstyles_bar),
                new SearchItemsModel(Utils.GetResources.GetString(Resource.String.lineChartName), Resource.Drawable.groupstyles_bar),

            };
            return items;
        }
        /// <summary>
        /// Volver a la pantalla anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }
        /// <summary>
        /// Eliminar el texto del editText
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelSearchButton_Click(object sender, EventArgs e)
        {
            EditText editText = FindViewById<EditText>(Resource.Id.edt_search_chart);
            editText.Text = "";
        }
        /// <summary>
        /// Animación cuando vuelves a la actividad anterior
        /// </summary>
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.abc_slide_out_bottom);
        }

        private class SearchItemsAdapter : RecyclerView.Adapter
        {

            private SearchItems _items;

            public SearchItemsAdapter(SearchItems items)
            {
                _items = items;
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                SearchItemsHolder searchItemsHolder = holder as SearchItemsHolder;
                searchItemsHolder.Name.Text = _items.Items[position].Name;
                //searchItemsHolder.Image.SetImageResource(_items.Items[position].Image);
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.items_search_layout, parent, false);
                SearchItemsHolder holder = new SearchItemsHolder(itemView);
                return holder;
            }

            public void FilterItems(List<SearchItemsModel> items)
            {
                _items.Items = items;
                NotifyDataSetChanged();
            }

            public override int ItemCount => _items.ItemsCount;

        }

        private class SearchItemsHolder : RecyclerView.ViewHolder
        {

            public TextView Name;
            //public ImageView Image;
            private View _itemView;

            public SearchItemsHolder(View itemView) : base(itemView)
            {

                Name = itemView.FindViewById<TextView>(Resource.Id.titleItemSearch);
                //Image = itemView.FindViewById<ImageView>(Resource.Id.imageItemSearch);

                //itemView.Click += (sender, e) => listener(base.LayoutPosition);

                //itemView.Click += OnClick;

                //_listener = listener;
                _itemView = (LinearLayout)itemView.FindViewById(Resource.Id.itemSearchLayout);

            }
        }

        private class ExtendOnEditorActionListener : Java.Lang.Object, TextView.IOnEditorActionListener
        {
            public bool OnEditorAction(TextView v, [GeneratedEnum] ImeAction actionId, KeyEvent e)
            {
                if (actionId == ImeAction.Search)
                {
                    //performSearch();
                    return true;
                }
                return false;
            }
        }

        private class ExtendOnTextChangedListener : Java.Lang.Object, ITextWatcher
        {

            private SearchItemsAdapter _adapter;
            private List<SearchItemsModel> _items;
            private ImageButton _cancelButton;

            public ExtendOnTextChangedListener(SearchItemsAdapter adapter, List<SearchItemsModel> items, ImageButton cancelButton)
            {
                _adapter = adapter;
                _items = items;
                _cancelButton = cancelButton;
            }

            public void AfterTextChanged(IEditable s)
            {
                _cancelButton.Visibility = (s.ToString() == "") ?  ViewStates.Gone : ViewStates.Visible;
            }

            public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
            {
                
            }

            public void OnTextChanged(ICharSequence s, int start, int before, int count)
            {
                Filter(s.ToString());
            }

            private void Filter(string searchText)
            {
                List<SearchItemsModel> searchItems = new List<SearchItemsModel>();
                foreach(SearchItemsModel item in _items)
                {
                    if (item.Name.ToLower().Contains(searchText.ToLower())) searchItems.Add(item);
                }
                _adapter.FilterItems(searchItems);
            }

        }

    }
}