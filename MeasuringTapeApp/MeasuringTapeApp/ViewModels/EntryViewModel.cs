using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeasuringTapeApp.Droid.Views
{
    public class EntryViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;

        public EntryViewModel(IMeasuringStorageService measuringStorageService,
                                IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _measuringStorageService = measuringStorageService;
        }


        private MeasuredObject obj;
        private MvxCommand addObject;

        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());

        public MvxCommand AddObject => addObject ?? (addObject = new MvxCommand(() =>
        {
            if (obj == null)
            {
                throw new Exception("Cannot add null Object");
            }
            _measuringStorageService.AddMeasuredObject(obj);
            _navigationService.Navigate<ListViewModel>();
        }));

    }
}
