using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MeasuringTapeApp.Models;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using MvvmCross.Droid.Support.V7.AppCompat;
using Square.Picasso;
using System.IO;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Measurement")]
    public class ListView : MvxAppCompatActivity<ListViewModel>
    {
        
        RecyclerView recyclerView;
        private ImageView _imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListView);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.new_counter_menu);
            SetSupportActionBar(toolbar);

            _imageView = FindViewById<ImageView>(Resource.Id.imageView);

            recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            var callback = new SwipeItemTouchHelperCallback(ViewModel);
            var touchHelper = new ItemTouchHelper(callback);
            touchHelper.AttachToRecyclerView(recyclerView);


            if (ViewModel.MeasuredObjects.Count > 0)
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(ViewModel.MeasuredObjects[0].ImageUri);
                Picasso.With(Application.Context).Load(uri).Into(_imageView);
            }

            // Set our view from the "main" layout resource

        }

        public class ImageHolder : RecyclerView.ViewHolder
        {
            public ImageView Image { get; private set; }
            public MeasuredObject Obj { get; private set; }

            // Get references to the views defined in the CardView layout.
            public ImageHolder(View itemView)
                : base(itemView)
            {
                // Locate and cache view references:
                Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);

                // Detect user clicks on the item view and report which item
                // was clicked (by layout position) to the listener:
            }
        }



        public RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.listitem, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            ImageHolder vh = new ImageHolder(itemView);
            return vh;
        }

            
        public void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ImageHolder xx = holder as ImageHolder;
            ImageView _imageView = xx.Image;

            // Load the photo caption from the photo album:
            Android.Net.Uri uri = Android.Net.Uri.Parse(ViewModel.MeasuredObjects[position].ImageUri);
            Picasso.With(Application.Context).Load(uri).Into(_imageView);
        }

        

        public override bool OnOptionsItemSelected(IMenuItem menu)
        {
            ViewModel.Reset.Execute();
            return true;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.new_counter_menu);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}