using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using MeasuringTapeApp.ViewModels;
using Android.Provider;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Entry", MainLauncher = false)]
    public class EntryView : MvxAppCompatActivity<EntryViewModel>
    {
        private ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EntryView);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var btnCamera = FindViewById<Button>(Resource.Id.btnCamera);
            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            btnCamera.Click += BtnCamera_Click;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imageView.SetImageBitmap(bitmap);
        }

        private void BtnCamera_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}