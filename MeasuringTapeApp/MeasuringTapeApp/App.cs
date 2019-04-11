using MeasuringTapeApp.Data;
using MeasuringTapeApp.Services;
using MeasuringTapeApp.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeasuringTapeApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            //Mvx.IoCProvider.RegisterType(typeof (MeasureDbContext), ()=>new MeasureDbContext());
            Mvx.IoCProvider.RegisterType<IMeasuringStorageService, SqlStorageService>();
            Mvx.IoCProvider.RegisterType<IGeolocationService, GeolocationService>();

            RegisterAppStart<ListViewModel>();
        }
    }
}