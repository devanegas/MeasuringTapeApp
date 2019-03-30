using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeasuringTapeApp.ViewModels
{
    public class EntryViewModel : MvxViewModel
    {
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;
        private IGeolocationService _geolocationService;

        public EntryViewModel(IMeasuringStorageService measuringStorageService,
                                IMvxNavigationService navigationService, IGeolocationService geolocationService)
        {
            _navigationService = navigationService;
            _measuringStorageService = measuringStorageService;
            _geolocationService = geolocationService;
        }


        private MeasuredObject obj;
        private MvxCommand next;

        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());

        public MvxCommand NextButton => next ?? (next = new MvxCommand(() =>
        {
            
            _measuringStorageService.AddMeasuredObject(obj);
            _navigationService.Navigate<MeasuringViewModel>();
            //_navigationService.Navigate<ListViewModel>();


        }));

    }
}
