using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Platforms.Android.Views;
using Android.Net;
using System;
using MeasuringTapeApp.Services;

namespace MeasuringTapeApp.Droid.Views
{
    [Activity(Label = "Entry", MainLauncher = false)]
    public class EntryView : MvxActivity<EntryViewModel>
    {
        IMeasuringStorageService _measuringStorageService;
        public EntryView()
        {
            _measuringStorageService = new SqlStorageService();
        }

        private ImageView _imageView;
        
        public static readonly int PickImageId = 1000;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.EntryView);
            _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += ButtonOnClick;
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                _imageView.SetImageURI(uri);

                ViewModel.Obj.ImageUri = uri.ToString();
                _measuringStorageService.UpdateMeasuredObject(ViewModel.Obj);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}