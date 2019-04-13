using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MeasuringTapeApp.ViewModels
{
    public class MeasuringContinuousViewModel : MvxViewModel<MeasuredObject>
    {
        private IGeolocationService _geolocationService;
        private IMvxNavigationService _navigationService;
        private IMeasuringStorageService _measuringStorageService;

        TimeSpan startTimeSpan = TimeSpan.Zero;
        TimeSpan periodTimeSpan = TimeSpan.FromSeconds(25);
        Timer timer;

        public MeasuringContinuousViewModel(IMeasuringStorageService measuringStorageService,
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




        private List<Location> locations = new List<Location>();
        public string Locations
        {
            get
            {
                string print1 = "";
                string print2 = "";
                foreach (var l in locations)
                {
                    print1 = "Latitude: " + l.Latitude.ToString();
                    print2 = " | Longitude: " + l.Longitude.ToString();

                }

                return String.Concat(print1, print2);

            }
        }


        private MvxCommand startMeasuring;
        private MvxCommand finishAndAddObject;

        public MvxCommand StartMeasuring => startMeasuring ?? (startMeasuring = new MvxCommand(async () =>
        {

            locations.Add(await _geolocationService.GetLocationAsync());
            await RaisePropertyChanged(nameof(Locations));
            //startTimeSpan = TimeSpan.Zero;
            //periodTimeSpan = TimeSpan.FromSeconds(5);
            
            timer = new Timer(async (e) =>
            {
                locations.Add(await _geolocationService.GetLocationAsync());
                await RaisePropertyChanged(nameof(Locations));

            }, null, startTimeSpan, periodTimeSpan);

            
            

        }));

        


        public MvxCommand FinishAndAddObject => finishAndAddObject ?? (finishAndAddObject = new MvxCommand(async () =>
        {
            timer.Dispose();
            var newLocation = await _geolocationService.GetLocationAsync();
            locations.Add(newLocation);
            double temp = 0;
            double multiplier = 0.001;

            switch (obj.Units)
            {
                case "Meters (m)":
                    multiplier = 1000;
                    break;
                case "Centimeters (cm)":
                    multiplier = 10000;
                    break;
                case "Yards (yd)":
                    multiplier = 1093.61;
                    break;
                case "Feet (ft)":
                    multiplier = 3280.84;
                    break;
                case "Kilometers (km)":
                    multiplier = 1;
                    break;
                case "Miles (mi)":
                    multiplier = 0.621371;
                    break;
                case "Inches (in)":
                    multiplier = 39370.1;
                    break;
            }

            for (int i = 0; i < locations.Count - 1; i++)
            {
                temp += Location.CalculateDistance(locations[i], locations[i + 1], DistanceUnits.Kilometers) * multiplier;
            }

            obj.Measurement = temp;

            //await RaisePropertyChanged(nameof(EndLocation));
            await _measuringStorageService.UpdateMeasuredObject(obj);
            await _navigationService.Navigate<ListViewModel>();
        }));

        public override void Prepare(MeasuredObject parameter)
        {
            obj = parameter;
        }
    }
}

