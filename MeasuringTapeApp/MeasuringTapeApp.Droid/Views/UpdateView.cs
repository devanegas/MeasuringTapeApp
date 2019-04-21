using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Update", MainLauncher = false)]
    public class UpdateView : MvxActivity<UpdateViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UpdateView);
        }
    }
}