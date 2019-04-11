using MeasuringTapeApp.ViewModels;
using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringTapeApp.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private readonly IMeasuringStorageService _measuringStorageService;
        private readonly IMvxNavigationService _navigationService;


        private ObservableCollection<MeasuredObject> measuredObjects;
        public ObservableCollection<MeasuredObject> MeasuredObjects { get => measuredObjects; }



        public ListViewModel(IMeasuringStorageService measuringStorageService,
                             IMvxNavigationService navigationService)
        {
            _measuringStorageService = measuringStorageService;
            _navigationService = navigationService;
            AsyncConstructor();
        }


        public async Task AsyncConstructor()
        {
            measuredObjects = await _measuringStorageService.GetAllMeasuredObjects();
            RaisePropertyChanged(nameof(MeasuredObjects));

        }

        private MvxCommand addNewObject;
        public MvxCommand AddNewObject => addNewObject ?? (addNewObject = new MvxCommand(() =>
        {
            _navigationService.Navigate<EntryViewModel>();
        }));


        private MvxCommand reset;
        public MvxCommand Reset => reset ?? (reset = new MvxCommand(() =>
        {
            _measuringStorageService.Reset();
            _navigationService.Navigate<ListViewModel>();
        }));
    }
}
