using Android.App;
using Android.OS;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Entry", MainLauncher = false)]
    public class EntryView : MvxActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EntryView);
        }
    }
}