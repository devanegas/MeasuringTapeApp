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
using MeasuringTapeApp.Data;

namespace MeasuringTapeApp.ViewModels
{
    public class MeasuringViewModel : MvxViewModel<MeasuredObject>
    {
        private IGeolocationService _geolocationService;
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;
        private MeasureDbContext _measureDbContext;

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
            measuredObjects = await _measuringStorageService.GetAllMeasuredObjects();
            RaisePropertyChanged(nameof(MeasuredObjects));

        }

        private ObservableCollection<MeasuredObject> measuredObjects;
        public ObservableCollection<MeasuredObject> MeasuredObjects { get => measuredObjects; }
        


        private MeasuredObject obj;
        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());



        private Location startLocation;
        public string StartLocation
        {
            get
            {
                string print1 = "Latitude: " + startLocation.Latitude.ToString();
                string print2 = " | Longitude: " + startLocation.Longitude.ToString();
                return String.Concat(print1, print2);
            }
        }
        private Location endLocation;
        public string EndLocation
        {
            get
            {
                string print1 = "Latitude: " + endLocation.Latitude.ToString();
                string print2 = " | Longitude: " + endLocation.Longitude.ToString();
                return String.Concat(print1, print2);
            }
        }


        private MvxCommand startMeasuring;
        private MvxCommand finishAndAddObject;

        public MvxCommand StartMeasuring => startMeasuring ?? (startMeasuring = new MvxCommand(async () =>
        {

            startLocation = await _geolocationService.GetLocationAsync();
            await RaisePropertyChanged(nameof(StartLocation));

        }));


        public MvxCommand FinishAndAddObject => finishAndAddObject ?? (finishAndAddObject = new MvxCommand(async () =>
        {

            endLocation = await _geolocationService.GetLocationAsync();
            obj.Measurement = Location.CalculateDistance(startLocation, endLocation, DistanceUnits.Kilometers)*1000;
            await RaisePropertyChanged(nameof(EndLocation));
            _measuringStorageService.UpdateMeasuredObject(obj);
            await _navigationService.Navigate<ListViewModel>();
        }));

        public override void Prepare(MeasuredObject parameter)
        {
            obj = parameter;
        }
    }
}
