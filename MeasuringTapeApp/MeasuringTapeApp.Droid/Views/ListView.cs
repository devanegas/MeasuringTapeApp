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
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Measurement", MainLauncher = true)]
    class ListView : MvxActivity<ListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListView);
        }
    }
}