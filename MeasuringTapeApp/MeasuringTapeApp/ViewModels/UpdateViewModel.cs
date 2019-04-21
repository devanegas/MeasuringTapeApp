using System;
using MvvmCross.ViewModels;
using MeasuringTapeApp.Models;
using MeasuringTapeApp.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MeasuringTapeApp.ViewModels
{
    public class UpdateViewModel : MvxViewModel<MeasuredObject>
    {

        private IMeasuringStorageService _measuringStorageService;
        private IMvxNavigationService _navigationService;

        public UpdateViewModel(IMeasuringStorageService measuringStorageService, IMvxNavigationService navigationService)
        {
            _measuringStorageService = measuringStorageService;
            _navigationService = navigationService;
        }
        private MeasuredObject obj;
        public MeasuredObject Obj => obj ?? (obj = new MeasuredObject());


        private MvxCommand updateObject;

        private MvxCommand next;
        public MvxCommand NextButton => next ?? (next = new MvxCommand(() =>
        {

            //_measuringStorageService.AddMeasuredObject(obj);
            //_navigationService.Navigate<MeasuringViewModel>();
            if (obj.Type.Equals("Linear"))
            {
                _navigationService.Navigate(typeof(MeasuringViewModel), obj);
            }
            else if (obj.Type.Equals("Multi-Linear"))
            {
                _navigationService.Navigate(typeof(MeasuringMultiLevelViewModel), obj);
            }
            else if (obj.Type.Equals("Walking"))
            {
                _navigationService.Navigate(typeof(MeasuringContinuousViewModel), obj);
            }
            else
                _navigationService.Navigate<MeasuringViewModel>();
        }));

        public MvxCommand UpdateObject => updateObject ?? (updateObject = new MvxCommand(() =>
        {
            if (obj == null)
            {
                throw new Exception("Cannot edit null object");
            }
            _measuringStorageService.UpdateMeasuredObject(obj);
            _navigationService.Navigate<ListViewModel>();
        }));

        public override void Prepare(MeasuredObject parameter)
        {
            obj = parameter;
        }
    }
}
