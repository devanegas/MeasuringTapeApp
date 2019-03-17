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
            Mvx.IoCProvider.RegisterType<IMeasuringStorageService, SqlStorageService>();

            RegisterAppStart<ListViewModel>();
        }
    }
}