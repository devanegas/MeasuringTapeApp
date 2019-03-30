using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MeasuringTapeApp.ViewModels
{
    public class MeasuringViewModel : MvxViewModel
    {
        private IGeolocationService _geolocationService;
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;
        private Location startLocation;
        private Location endLocation;

        public MeasuringViewModel(IMeasuringStorageService measuringStorageService,
                                IMvxNavigationService navigationService, IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
            _navigationService = navigationService;
            _measuringStorageService = measuringStorageService;
            AsyncConstructor();
        }

        public async Task AsyncConstructor()
        {
            measuredObjects = await _measuringStorageService.getAllMeasuredObjects();
            RaisePropertyChanged(nameof(MeasuredObjects));

        }

        private ObservableCollection<MeasuredObject> measuredObjects;
        public ObservableCollection<MeasuredObject> MeasuredObjects { get => measuredObjects; }

        private MeasuredObject obj;
        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());


        private MvxCommand startMeasuring;
        private MvxCommand finishAndAddObject;

        public MvxCommand StartMeasuring => startMeasuring ?? (startMeasuring = new MvxCommand(async () =>
        {

            //if (obj == null)
            //{
            //    throw new Exception("Cannot add null Object");
            //}
            //_measuringStorageService.AddMeasuredObject(obj);
            //_navigationService.Navigate<ListViewModel>();
            startLocation = await _geolocationService.GetLocationAsync();

        }));


        public MvxCommand FinishAndAddObject => finishAndAddObject ?? (finishAndAddObject = new MvxCommand(async () =>
        {

            endLocation = await _geolocationService.GetLocationAsync();
            obj.Measurement = Location.CalculateDistance(startLocation, endLocation, DistanceUnits.Kilometers);
            _measuringStorageService.AddMeasuredObject(obj);
            _navigationService.Navigate<ListViewModel>();
        }));

        //public override void Prepare(MeasuredObject parameter)
        //{
        //    obj = parameter;
        //}
    }
}
