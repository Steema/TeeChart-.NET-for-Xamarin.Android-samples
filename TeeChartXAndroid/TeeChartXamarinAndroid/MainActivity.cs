using System;
using Android;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.Transitions;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using TeeChartXamarinAndroid.Model;
using TeeChartXamarinAndroid.ViewModel;

namespace TeeChartXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {

        GroupStyles groupStyles;
        GroupStylesAdapter groupStylesAdapter;
        RecyclerView vRecyclerViewer;
        LinearLayoutManager linearLayoutManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // RecyclerViewer items
            groupStyles = new GroupStyles();

            SetContentView(Resource.Layout.activity_main);

            // Get RecyclerViewer view
            vRecyclerViewer = (RecyclerView)FindViewById(Resource.Id.homeRecyclerView);

            // Get toolbar and setActionBar
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            AppBarLayout appBarLayout = FindViewById<AppBarLayout>(Resource.Id.topbarLayout);

            vRecyclerViewer.AddOnScrollListener(new GroupStylesScroll(appBarLayout, toolbar));

            // Set layoutManager to RecyclerViewer  
            linearLayoutManager = new LinearLayoutManager(this);
            vRecyclerViewer.SetLayoutManager(linearLayoutManager);

            // RecyclerViewer adapter and setAdapter
            groupStylesAdapter = new GroupStylesAdapter(groupStyles);
            groupStylesAdapter.ItemClick += OnItemClick;
            vRecyclerViewer.SetAdapter(groupStylesAdapter);


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);            

            Window.SetStatusBarColor(Utils.GetResources.GetColor(this, Resource.Color.colorPrimaryOver));

        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.search_toolbar_item)
            {
                Android.Content.Intent intent = new Android.Content.Intent(this, typeof(ActivitySearch));
                StartActivity(intent);
                OverridePendingTransition(Resource.Animation.abc_slide_in_bottom, Resource.Animation.fade_out);
            }

            return base.OnOptionsItemSelected(item);
        }
        /*
        public void circleReveal(int viewID, int posFromRight, boolean containsOverflow, final boolean isShow)
        {
            final View myView = FindViewById(viewID);

            int width = myView.getWidth();

            if (posFromRight > 0)
                width < span class="pl-k">-=</span>(posFromRight<span class="pl-k">*</span>getResources()<span class="pl-k">.</span>getDimensionPixelSize(<span class="pl-smi">R</span><span class="pl-k">.</span>dimen<span class="pl-k">.</span>abc_action_button_min_width_material))<span class="pl-k">-</span>(getResources()<span class="pl-k">.</span>getDimensionPixelSize(<span class="pl-smi">R</span><span class="pl-k">.</span>dimen<span class="pl-k">.</span>abc_action_button_min_width_material)<span class="pl-k">/</span> <span class="pl-c1">2</span>);

  if(containsOverflow)
    width-=getResources().getDimensionPixelSize(R.dimen.abc_action_button_min_width_overflow_material);

        int cx = width;
        int cy = myView.getHeight() / 2;

        Animator anim;
  if(isShow)
    anim = ViewAnimationUtils.createCircularReveal(myView, cx, cy, 0, (float)width);
  else
    anim = ViewAnimationUtils.createCircularReveal(myView, cx, cy, (float) width, 0);

  anim.setDuration((long)220);

  // make the view invisible when the animation is done
  anim.addListener(new AnimatorListenerAdapter()
        {
            @Override
  public void onAnimationEnd(Animator animation)
            {
                if (!isShow)
                {
                    super.onAnimationEnd(animation);
                    myView.setVisibility(View.INVISIBLE);
                }
            }
        });

  // make the view visible and start the animation
  if(isShow)
    myView.setVisibility(View.VISIBLE);

        // start the animation
        anim.start();
}
*/

    public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_home)
            {
                // Handle the camera action
            }
            else if(id == Resource.Id.nav_web)
            {

            }
            else if (id == Resource.Id.nav_github)
            {

            }
            else if (id == Resource.Id.nav_documentation)
            {

            }
            else if (id == Resource.Id.nav_settings)
            {

            }
            else if (id == Resource.Id.nav_settings)
            {

            }
            else if (id == Resource.Id.nav_aboutus)
            {

            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        void OnItemClick(object sender, int position)
        {
            int nElement = position + 1;
            Toast.MakeText(this, "This is photo number " + nElement, ToastLength.Short).Show();
        }

        /// <summary>
        /// Main class adapter for recyclerView
        /// </summary>
        private class GroupStylesAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
        {

            private GroupStyles _groupStyles;
            public event EventHandler<int> ItemClick;

            public GroupStylesAdapter(GroupStyles groupStyles)
            {

                _groupStyles = groupStyles;

            }

            public override int ItemCount => _groupStyles.Items.Length;

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                GroupStylesHolder viewHolder = holder as GroupStylesHolder;
                viewHolder.Image.SetImageResource(_groupStyles.Items[position].Image);
                viewHolder.Title.Text = _groupStyles.Items[position].Title;
                viewHolder.Description.Text = _groupStyles.Items[position].Description;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.groupstyles_cardview, parent, false);
                GroupStylesHolder holder = new GroupStylesHolder(itemView, OnClick);
                return holder;
            }

            void OnClick(int position)
            {
                if (ItemClick != null)
                    ItemClick(this, position);
            }

        }

        /// <summary>
        /// Main class holder for recyclerView
        /// </summary>
        private class GroupStylesHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
        {

            public ImageView Image { get; set; }
            public TextView Title { get; set; }
            public TextView Description { get; set; }

            private Action<int> _listener;
            private Android.Support.V7.Widget.CardView _itemView;

            public GroupStylesHolder(View itemView, Action<int> listener) : base(itemView)
            {

                Image = itemView.FindViewById<ImageView>(Resource.Id.cardViewImage);
                Title = itemView.FindViewById<TextView>(Resource.Id.cardViewTitle);
                Description = itemView.FindViewById<TextView>(Resource.Id.cardViewDescription);

                //itemView.Click += (sender, e) => listener(base.LayoutPosition);

                itemView.Click += OnClick;

                _listener = listener;
                _itemView = (Android.Support.V7.Widget.CardView)itemView.FindViewById(Resource.Id.cardViewGroupStyles);

            }

            void OnClick(object sender, EventArgs e)
            {
                _listener(base.LayoutPosition);
            }

        }

        /// <summary>
        /// Main class scrollListener for recyclerView
        /// </summary>
        private class GroupStylesScroll : Android.Support.V7.Widget.RecyclerView.OnScrollListener
        {

            private static int SCROLL_DIRECTION_UP = -1;
            private Android.Support.Design.Widget.AppBarLayout _appBarLayout;
            private Android.Support.V7.Widget.Toolbar _toolbar;

            public GroupStylesScroll(Android.Support.Design.Widget.AppBarLayout barLayout, Android.Support.V7.Widget.Toolbar toolbar)
            {
                _appBarLayout = barLayout;
                _toolbar = toolbar;
            }

            public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
            {

                if (recyclerView.CanScrollVertically(SCROLL_DIRECTION_UP))
                {
                    _appBarLayout.Elevation = 8;
                }
                else
                {
                    _appBarLayout.Elevation = 0;
                }

            }

        }

    }
}

