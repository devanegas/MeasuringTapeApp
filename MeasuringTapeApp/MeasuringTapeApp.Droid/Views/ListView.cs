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
using MeasuringTapeApp.Models;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Measurement")]
    public class ListView : MvxActivity<ListViewModel>
    {
        private ImageView _imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);

            //foreach (MeasuredObject obj in ViewModel.MeasuredObjects)
            //{
            //    _imageView = FindViewById<ImageView>(Resource.Id.imageView2);
            //    _imageView.SetImageURI(Android.Net.Uri.Parse(obj.ImageUri));
            //}



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}