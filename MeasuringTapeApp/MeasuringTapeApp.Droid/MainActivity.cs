using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Core;
using System;
using MeasuringTapeApp;

namespace MeasuringTapeApp
{
    [Application]
    public class MainActivity : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public MainActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }
    }
}