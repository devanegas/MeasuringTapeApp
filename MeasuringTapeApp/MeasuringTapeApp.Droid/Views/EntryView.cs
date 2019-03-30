﻿using Android.App;
using Android.OS;
using Android.Runtime;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Entry", MainLauncher = false)]
    public class EntryView : MvxActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EntryView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}